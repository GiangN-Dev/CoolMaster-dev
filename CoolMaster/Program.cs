// Các namespace quan trọng từ cả 2 file
using CoolMaster.Common;
using CoolMaster.Data;
using CoolMaster.Data.Repositories;
using CoolMaster.Forms;
using CoolMaster.Forms.Main;
using CoolMaster.Forms.Sales;
using CoolMaster.Model;
using CoolMaster.Repositories;
using CoolMaster.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolMaster
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["CoolMasterConnString"].ConnectionString;

                Database.SetInitializer(new CoolMasterInitializer());
                using (var db = new CoolMasterContext())
                {
                    db.Database.Initialize(force: false);
                }

                IServiceTicketRepository ticketRepo = new ServiceTicketRepository(connStr);
                IServiceTicketService ticketService = new ServiceTicketService(ticketRepo);

                frmSignIn login = new frmSignIn();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    var loggedUser = login.LoggedUser;

                    Application.Run(new frmMain(connStr, ticketService, loggedUser));
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}