using CoolMaster.Data.Repositories;
using CoolMaster.Forms;
using CoolMaster.Forms.Main;
using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolMaster.Common;
using CoolMaster.Forms.Sales;
using CoolMaster.Repositories; // ensure repository namespace

namespace CoolMaster
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Lấy chuỗi kết nối
            string connStr = ConfigurationManager.ConnectionStrings["CoolMasterConnString"].ConnectionString;

            try
            {
                // 2. Khởi tạo Database (Code First)
                Database.SetInitializer(new CoolMasterInitializer());
                using (var db = new CoolMasterContext())
                {
                    db.Database.Initialize(force: false);
                }

                // --- TẠO REPOSITORY + SERVICE CHO SERVICE TICKET VÀ TRUYỀN VÀO frmMain ---
                IServiceTicketRepository ticketRepo = new ServiceTicketRepository(connStr);
                IServiceTicketService ticketService = new ServiceTicketService(ticketRepo);

                // 3. Luồng chạy: Login -> Main
                frmSignIn login = new frmSignIn();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Pass connection string and ticketService into frmMain
                    Application.Run(new frmMain(connStr, ticketService));
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động: " + ex.Message);
            }
        }
    }
}