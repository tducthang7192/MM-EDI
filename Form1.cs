using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinSCP;


namespace MM_Project
{
    public partial class Form1 : Form
        
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string token = "";
        private void ReadFileMasterData()
        {
            string destDirectory = Constant.PATH_HISTORY_MASTERDATA;
            string pathDirectory = Constant.PATH_MASTERDATA;
            string fileName = "";
            string path = "";
            string[] supplierFiles = Directory.GetFiles(pathDirectory, "*.DAT");
            for (int i = 0; i < supplierFiles.Count(); i++)
            {
                path = supplierFiles[i];
                string[] allText = File.ReadAllLines(path);
                int numberRow = allText.Count();
                txtInform1.AppendText(string.Format(numberRow.ToString()));
                int countRowSuccess = 0;

                fileName = path.Substring(pathDirectory.Length + 1);
                ResultDatabase_Model result = new ResultDatabase_Model();
                foreach (string text in allText)
                {
                    result = CountLineSuccess_MasterData(text, countRowSuccess, fileName);
                    countRowSuccess = result.numberRowSuccess;
                    txtInform1.AppendText("\n import thành công " + string.Format(countRowSuccess.ToString()) + "\n");
                }
                if (numberRow == countRowSuccess)
                {
                    this.MoveFile(pathDirectory, destDirectory, fileName, path);
                }


            }
        }

        private async Task<string> Gettoken()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "token" + ".txt";
            token = await ClientHttpController.GetToken();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(token);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(token);

                }
            }
            return token;
        }

        private void MoveFile(string source, string dest, string fileName, string path)
        {
            bool check = false;

            File.Copy(Path.Combine(source, fileName), Path.Combine(dest, fileName), true);
            check = true;

            if (check)
            {
                File.Delete(path);
            }

        }


        private ResultDatabase_Model CountLineSuccess_MasterData(string text, int count, string fileName)
        {
            int indicator = DAL.IntReturn(text.Substring(0, 1));
            ResultDatabase_Model result = new ResultDatabase_Model();
            SupplierController supplierControl = new SupplierController();
            ArticlesController_North articleControl = new ArticlesController_North();

            if (indicator == 1 || indicator == 2)
            {
                result = supplierControl.InsertDatabase(text, indicator, fileName);
                result.indicator = indicator;
            }
            else if (indicator == 3 || indicator == 4)
            {
                result = articleControl.InsertDatabase(text, indicator, fileName);
                result.indicator = indicator;
            }

            if (result.check == true)
            {
                count++;
                result.numberRowSuccess = count;
            }
            else
            {
                result.numberRowSuccess = count;
            }
    
            return result;
        }

        private ResultDatabase_Model CountLineSuccess_SO(string text, int count, string fileName)
        {
            int indicator = DAL.IntReturn(text.Substring(0, 1));
            ResultDatabase_Model result = new ResultDatabase_Model();
            SOController_North soControl = new SOController_North();

                result = soControl.InsertDatabase(text, indicator, fileName);
                result.indicator = indicator;

            if (result.check == true)
            {
                count++;
                result.numberRowSuccess = count;
            }
            else
            {
                result.numberRowSuccess = count;
            }
            return result;
        }

        private ResultDatabase_Model CountLineSuccess_PO(string text, int count, string fileName)
        {
            int indicator;
            ResultDatabase_Model result = new ResultDatabase_Model();
            POController_North poController = new POController_North();
                indicator= DAL.IntReturn(text.Substring(0, 1));              
                result = poController.InsertDatabase(text, indicator, fileName);

            if (result.check == true)
            {
                count++;
                result.numberRowSuccess = count;
            }
            else
            {
                result.numberRowSuccess = count;
            }

          
            return result;
        }


        private void Post_Article_North()
        {
            ArticlesController_North articleControl = new ArticlesController_North();                 
            articleControl.PostToIon();
            articleControl.Post_Update_Sku();
        }

        private void Post_Article_South()
        {
            ArticlesController_South articleControl = new ArticlesController_South();
            articleControl.PostToIon();
            articleControl.Post_Update_Sku();
        }

        private void Post_SO_North()
        {
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_SO + "\r\n", "North"));
            SOController_North soController = new SOController_North();
            soController.PostToIon_Xdock();
            soController.PostToIon();
            soController.PostToIon_Return();
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_SO + "\r\n", "North"));
        }
        
        private void Post_PO_North()
        {
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_PO + "\r\n", "North"));
            POController_North poController = new POController_North();
            poController.PostToIon();
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_PO + "\r\n", "North"));
        }

        private void Post_SO_South()
        {
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_SO + "\r\n", "South"));
            SOController_South soController = new SOController_South();
            soController.PostToIon();
            soController.PostToIon_Return();
            soController.PostToIon_Xdock();
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_SO + "\r\n", "South"));
        }

        private void Post_PO_South()
        {
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_PO + "\r\n", "South"));
            POController_South poController = new POController_South();
            poController.PostToIon();
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_PO + "\r\n", "South"));
        }

        private void Post_ASN_South()
        {
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_ASN + "\r\n", "South"));
            ASNController_South asnController = new ASNController_South();
            asnController.PostToIon();
            txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_ASN + "\r\n", "South"));
        }

       

        private void Post_Supplier_South()
        {
            SupplierController supplier = new SupplierController();
            supplier.PostToIon_South();
        }
        private void Post_Supplier_North()
        {
            SupplierController supplier = new SupplierController();
            supplier.PostToIon_North();
        }



        private void ConnectFTP()
        {
            txtInform1.AppendText("\r\n Start Connect SFTP .... \r\n");
            Response_SFTP result_SFTP = new Response_SFTP();
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = "sftp01.mmvietnam.com",
                UserName = "lspgmdprod",
                SshHostKeyFingerprint = "ssh-ed25519 255 gbfFmqgr8jbd8lAQOxHTcVQmNCk5OlnD8MXGMerAttg=",
                SshPrivateKeyPath = @"E:\Software\MMVN\lspgmdprod.ppk",

            };

            using (Session session = new Session())
            {
                try
                {
                    session.Open(sessionOptions);
                }
                catch (InvalidOperationException e)
                {
                    result_SFTP.Handle_Error_Sftp("Connect", e.Message.ToString());
                    txtInform1.AppendText("\r\n Connect SFTP Fail .... \r\n");
                    return;
                }

                
                    const string remotePath = Constant.PATH_GETFILE_SFTP;
                    RemoteDirectoryInfo directory = session.ListDirectory(remotePath);

                    foreach (RemoteFileInfo fileInfo in directory.Files)
                    {
                        if (!fileInfo.IsDirectory && fileInfo.Name.EndsWith(".DAT", StringComparison.OrdinalIgnoreCase))
                        {
                            string tempPath = Path.GetTempFileName();
                            var sourcePath = RemotePath.EscapeFileMask(remotePath + "/" + fileInfo.Name);
                            string targerPath = Constant.PATH_MOVEFILE_SFTP;
                            string errorPath = Constant.PATH_MOVEFILE_ERROR_SFTP;
                            string fileName = fileInfo.Name;
                            string category = fileName.Substring(9, 2).ToUpper();
                            string backupPath = string.Format(Constant.PATH_BACKUP, fileName);
                        try
                        {
                            session.GetFiles(sourcePath, backupPath).Check();
                            session.GetFiles(sourcePath, tempPath).Check();
                        }
                        catch(Exception e)
                        {
                            result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                        }
                            

                            string[] lines = File.ReadAllLines(tempPath);
                            int numberRow = lines.Count();
                            int countRowSuccess = 0;

                            ResultDatabase_Model result = new ResultDatabase_Model();
                            if (category == "MD")
                            {
                                this.Show_Message_Start(fileName);

                                foreach (string text in lines)
                                {
                                try
                                {
                                    int indicator = DAL.IntReturn(text.Substring(0, 1));
                                }
                                catch (Exception e)
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }
                                result = CountLineSuccess_MasterData(text, countRowSuccess, fileName);
                                    countRowSuccess = result.numberRowSuccess;
                                }
                                if (numberRow == countRowSuccess)
                                {
                                    this.Show_Message_Success(fileName);

                                    targerPath = string.Format(targerPath, fileName);                                   
                                    try
                                    {
                                        session.MoveFile(sourcePath, targerPath);
                                    }
                                    catch (Exception e)
                                    {
                                        result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());                                      
                                        continue;
                                    }
                                }
                                else
                                {
                                try
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    this.Show_Message_Error(fileName, countRowSuccess);
                                }
                                catch (Exception e)
                                {
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }
                            }

                            }
                            else if (category == "PO")
                            {
                                this.Show_Message_Start(fileName);

                                foreach (string text in lines)
                                {
                                try
                                {
                                    int indicator = DAL.IntReturn(text.Substring(0, 1));
                                }
                                catch(Exception e)
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }
                                 
                                 result = CountLineSuccess_PO(text, countRowSuccess, fileName);

                                    countRowSuccess = result.numberRowSuccess;

                                }
                                if (numberRow == countRowSuccess)
                                {
                                    this.Show_Message_Success(fileName);

                                    targerPath = string.Format(targerPath, fileName);
                                    try
                                    {
                                        session.MoveFile(sourcePath, targerPath);
                                    }
                                    catch (Exception e)
                                    {
                                        result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                        continue;
                                    }
                                }
                                else
                                {
                                try
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    this.Show_Message_Error(fileName, countRowSuccess);
                                }
                                catch (Exception e)
                                {
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }
                            }
                            }
                            else if (category == "SO")
                            {
                                this.Show_Message_Start(fileName);

                                foreach (string text in lines)
                                {
                                try
                                {
                                    int indicator = DAL.IntReturn(text.Substring(0, 1));
                                }
                                catch (Exception e)
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }
                                result = CountLineSuccess_SO(text, countRowSuccess, fileName);
                                countRowSuccess = result.numberRowSuccess;
                                }
                                if (numberRow == countRowSuccess)
                                {
                                    this.Show_Message_Success(fileName);
                                    targerPath = string.Format(targerPath, fileName);
                                    try
                                    {
                                        session.MoveFile(sourcePath, targerPath);
                                    }
                                    catch (Exception e)
                                    {
                                        result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                        continue;
                                    }

                                }
                                else
                                {
                                try
                                {
                                    errorPath = string.Format(errorPath, fileName);
                                    session.MoveFile(sourcePath, errorPath);
                                    this.Show_Message_Error(fileName, countRowSuccess);
                                }
                                catch (Exception e)
                                {
                                    result_SFTP.Handle_Error_Sftp(fileName, e.Message.ToString());
                                    continue;
                                }


                                }
                            }
                        }
                    }


                session.Close();

            } 
        }

        private void Show_Message_Start(string fileName)
        {
            txtInform1.AppendText("\r\n Bắt đầu đọc file: " + fileName + "\r\n");
        }
        private void Show_Message_Success(string fileName)
        {
            txtInform1.AppendText("\r\n Đọc xong file: " + fileName + "\r\n");
        }
        private void Show_Message_Error(string fileName, int countRowSuccess)
        {
            txtInform1.AppendText("\r\n" + fileName + "có dòng lỗi" + " \r\n");
            txtInform1.AppendText("\r\n " + fileName + " Đọc thành công : " + countRowSuccess.ToString() + "\r\n");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
        }

        private void  timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            int minute = time.Minute;
            if (minute == 15 || minute == 30 || minute == 45)
            {
                this.ConnectFTP();

                txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_MD + "\r\n", "North"));
                this.Post_Supplier_North();
                this.Post_Article_North();
                txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_MD + "\r\n", "North"));
                txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_START_MD + "\r\n", "South"));
                this.Post_Supplier_South();
                this.Post_Article_South();
                txtInform2.AppendText(string.Format("\r\n" + Constant.INFORM_END_MD + "\r\n", "South"));
                this.Post_PO_South();
                this.Post_SO_South();
                this.Post_ASN_South();
                this.Post_PO_North();
                this.Post_SO_North();
                System.Threading.Thread.Sleep(50000);
                txtInform1.Clear();
                txtInform2.Clear();
            }
        }
    }
}
