using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RevisionPapeleraCorr
{
    public partial class Form1 : Form
    {
        private SqlConnection con = null;
        string Almacen, FABP, ftpAddress, username, password, FechaCreacion;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                buscar();
                generar();

                this.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                txtInfo.Text = "Mensaje: " + ex.ToString();
            }
}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            dgvFABP.Refresh();

            txtInfo.Text = "Buscando... ";

            string strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            con = new SqlConnection(strConnString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_BuscarFAPSPendientesCorr";
            cmd.Connection = con;
            cmd.CommandTimeout = 0;

            Console.WriteLine(DateTime.Now);
            adapter.Fill(dt);
            Console.WriteLine(DateTime.Now);
            dt.AcceptChanges();
            dgvFABP.DataSource = dt;
            con.Close();
            txtInfo.Text = "Se termino la busqueda con " + dgvFABP.Rows.Count + " registros";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generar();
        }

        private void generar()
        {
            if(dgvFABP.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvRenglon in dgvFABP.Rows)
                {
                    Almacen = (dgvRenglon.Cells[1].Value.ToString());
                    FABP = (dgvRenglon.Cells[2].Value.ToString());
                    ftpAddress = (dgvRenglon.Cells[3].Value.ToString());
                    username = (dgvRenglon.Cells[4].Value.ToString());
                    password = (dgvRenglon.Cells[5].Value.ToString());
                    FechaCreacion = (dgvRenglon.Cells[6].Value.ToString());

                    dgvCSV.Refresh();

                    txtInfo.Text = "Generando CSV " + FABP + " ... ";

                    string strConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                    con = new SqlConnection(strConnString);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GenerarCSVRevisionFABP";
                    cmd.Parameters.Add("@Almacen", SqlDbType.VarChar).Value = Almacen;
                    cmd.Parameters.Add("@FABP", SqlDbType.VarChar).Value = FABP;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;

                    Console.WriteLine(DateTime.Now);
                    adapter.Fill(dt);
                    Console.WriteLine(DateTime.Now);
                    dt.AcceptChanges();
                    dgvCSV.DataSource = dt;
                    con.Close();
                    txtInfo.Text = "Se termino la generacion del " + FABP + " con " + dgvCSV.Rows.Count + " registros";

                    Enviar();
                }
            }            
        }

        private void Enviar()
        {
            try
            {
                if (dgvCSV.Rows.Count > 0)
                {
                    string rutaDirectorio = ConfigurationManager.AppSettings["rutaDirectorio"];
                    string nombreArchivo = "CSV_" + FABP + "_" + Almacen + "_" + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".csv";

                    txtInfo.Text = "Se creo el archivo " + nombreArchivo;

                    TextWriter ArchivoDirectorio = new StreamWriter(rutaDirectorio + @"\" + nombreArchivo);

                    txtInfo.Text = "PROCESANDO";
                    for (int i = 0; i < dgvCSV.Rows.Count; i++)
                    {
                        string documento = Convert.ToString(dgvCSV.Rows[i].Cells["Rollos"].Value.ToString());
                        ArchivoDirectorio.WriteLine($"{documento}");
                        txtInfo.Text = i.ToString();
                    }
                    txtInfo.Text = "Se termino de llenar el archivo con " + dgvCSV.Rows.Count + " registros";
                    ArchivoDirectorio.Close();
                    dgvCSV.DataSource = null;
                    dgvCSV.Rows.Clear();

                    //EnvioFTP
                    try
                    {
                        using (StreamReader stream = new StreamReader(rutaDirectorio + @"\" + nombreArchivo))
                        {
                            byte[] buffer = Encoding.Default.GetBytes(stream.ReadToEnd());
                            WebRequest request = WebRequest.Create("ftp://" + ftpAddress + "/" + nombreArchivo);
                            request.Method = WebRequestMethods.Ftp.UploadFile;
                            request.Credentials = new NetworkCredential(username, password);
                            Stream reqStream = request.GetRequestStream();
                            reqStream.Write(buffer, 0, buffer.Length);
                            reqStream.Flush();
                            reqStream.Close();
                        }
                        WebRequest webreq = WebRequest.Create("ftp://" + ftpAddress + "/" + nombreArchivo);
                        webreq.Method = WebRequestMethods.Ftp.GetFileSize;
                        webreq.Credentials = new NetworkCredential(username, password);

                        FtpWebResponse response = (FtpWebResponse)webreq.GetResponse();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        txtInfo.Text = "Mensaje: " + ex.ToString();
                    }
                }
                else
                {
                    txtInfo.Text = "Mensaje: Sin registros que procesar";
                }
            }
            catch (Exception ex)
            {
                con.Close();
                txtInfo.Text = "Mensaje: " + ex.ToString();
            }
        }
    }
}
