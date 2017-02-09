using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using MiniApp.DBUtility;
using MiniApp.localhost;

namespace MiniApp
{
    public partial class BaseWin : Form
    {
        public BaseWin()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lv_TeeTiem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void BaseWin_Load(object sender, EventArgs e)
        {
            var getTeeTimeThread = new Thread(GetTeeTimeMethod) {IsBackground = true};
            getTeeTimeThread.Start();
            var writeInOrder = new Thread(WriteInOrder) {IsBackground = true};
            writeInOrder.Start();
        }

        /// <summary>
        ///     提交TeeTime
        /// </summary>
        /// <param name="obj"></param>
        private void GetTeeTimeMethod(object obj)
        {
            const string sql = "select * from GroupSource_TeeTime";
            while (true)
            {
                try
                {
                    Thread.Sleep(2000);
                    var proDs = DbHelperSQL.ExecuteSql("EXEC Proc_InterfaceTeeTime");
                    var teeTimeDataSet = DbHelperSQL.Query(sql);
                    var service = new ServiceClient();
                    service.UpdateTeetimeMethod(teeTimeDataSet);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    AddListView(exception.ToString());
                }
            }
        }

        /// <summary>
        ///     写入预约订单
        /// </summary>
        private void WriteInOrder(object obj)
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(2000);
                    var service = new ServiceClient();
                    var resParam = service.GetAppointmentMethod();
                    var cmdList = new List<string>();
                    foreach (DataRow row in resParam.Tables[0].Rows)
                    {
                        for (var i = 0; i < (int) row["NUMBER_OF_PEOPLE"]; i++)
                        {
                            var cmdSql = string.Format(@"EXEC dbo.Proc_InterfaceBooking @ResourceId = {0}, -- int
								@CsmrName = '{1}', -- varchar(50)
								@BookingTime = '{2}', -- varchar(50)
								@CsmrPhoneNumber = '{3}', -- varchar(50)
								@SponsorId = {4}, --int
								@NUMBER_OF_PEOPLE = {5} --int",
                                row["COURT_ID"],
                                row["FULL_NAME"],
                                row["TEETIME"],
                                row["CONTACT_NUMBER"],
                                row["SERIAL_NUMBER"],
                                row["NUMBER_OF_PEOPLE"]);
                            cmdList.Add(cmdSql);
                        }
                    }
                    DbHelperSQL.ExecuteSqlTran(cmdList);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    AddListView(exception.ToString());
                }
            }
        }

        /// <summary>
        ///     异常时间轴写入listView
        /// </summary>
        /// <param name="exception"></param>
        private void AddListView(string exception)
        {
            try
            {
                var li = new ListViewItem();
                li.SubItems[0].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                li.SubItems.Add(exception);
                lv_TeeTiem.Items.Add(li);

                lv_TeeTiem.Columns[0].Width = -1;
                lv_TeeTiem.Columns[1].Width = -1;
                lv_TeeTiem.Columns[0].Width = -2;
                lv_TeeTiem.Columns[1].Width = -2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     隐藏任务栏图标,显示系统托盘图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseWin_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        /// <summary>
        ///     还原窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Activate();
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}