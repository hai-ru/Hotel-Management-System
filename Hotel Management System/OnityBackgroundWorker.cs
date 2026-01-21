using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    /// <summary>
    /// Background worker untuk operasi Onity yang berat
    /// Mencegah UI freeze saat komunikasi dengan hardware
    /// </summary>
    internal class OnityBackgroundWorker
    {
        private BackgroundWorker worker;
        private OnityConnection onityConn;
        
        public delegate void OnityOperationCompleted(bool success, string message);
        public event OnityOperationCompleted OperationCompleted;
        
        public delegate void OnityProgressChanged(int progressPercentage, string status);
        public event OnityProgressChanged ProgressChanged;

        public OnityBackgroundWorker()
        {
            onityConn = new OnityConnection();
            InitializeWorker();
        }

        private void InitializeWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        /// <summary>
        /// Create card di background thread
        /// </summary>
        public void CreateCardAsync(string room, DateTime endDate)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("Onity operation is in progress. Please wait...", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var operation = new OnityOperation
            {
                Type = OnityOperationType.CreateCard,
                Room = room,
                EndDate = endDate
            };

            worker.RunWorkerAsync(operation);
        }

        /// <summary>
        /// Checkout card di background thread
        /// </summary>
        public void CheckoutCardAsync(string room)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("Onity operation is in progress. Please wait...", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var operation = new OnityOperation
            {
                Type = OnityOperationType.CheckoutCard,
                Room = room
            };

            worker.RunWorkerAsync(operation);
        }

        /// <summary>
        /// Read card di background thread
        /// </summary>
        public void ReadCardAsync()
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("Onity operation is in progress. Please wait...", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var operation = new OnityOperation
            {
                Type = OnityOperationType.ReadCard
            };

            worker.RunWorkerAsync(operation);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var operation = e.Argument as OnityOperation;
            if (operation == null)
            {
                e.Result = new OnityResult { Success = false, Message = "Invalid operation" };
                return;
            }

            BackgroundWorker bgWorker = sender as BackgroundWorker;
            
            try
            {
                bgWorker.ReportProgress(10, "Connecting to Onity device...");
                Thread.Sleep(200); // Simulate connection delay
                
                bool success = false;
                string message = "";
                string roomNumber = "";

                switch (operation.Type)
                {
                    case OnityOperationType.CreateCard:
                        bgWorker.ReportProgress(30, "Creating card...");
                        success = onityConn.createCard(operation.Room, operation.EndDate);
                        message = success ? "Card created successfully" : "Failed to create card";
                        bgWorker.ReportProgress(90, "Card creation completed");
                        break;

                    case OnityOperationType.CheckoutCard:
                        bgWorker.ReportProgress(30, "Checking out card...");
                        success = onityConn.checkoutCard(operation.Room);
                        message = success ? "Card checked out successfully" : "Failed to checkout card";
                        bgWorker.ReportProgress(90, "Checkout completed");
                        break;

                    case OnityOperationType.ReadCard:
                        bgWorker.ReportProgress(30, "Reading card...");
                        roomNumber = onityConn.readCard();
                        success = !string.IsNullOrEmpty(roomNumber);
                        message = success ? $"Card read: Room {roomNumber}" : "Failed to read card";
                        bgWorker.ReportProgress(90, "Reading completed");
                        break;
                }

                bgWorker.ReportProgress(100, "Operation completed");

                e.Result = new OnityResult
                {
                    Success = success,
                    Message = message,
                    RoomNumber = roomNumber
                };
            }
            catch (Exception ex)
            {
                e.Result = new OnityResult
                {
                    Success = false,
                    Message = $"Onity error: {ex.Message}"
                };
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string status = e.UserState as string;
            ProgressChanged?.Invoke(e.ProgressPercentage, status);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                OperationCompleted?.Invoke(false, $"Error: {e.Error.Message}");
            }
            else if (e.Cancelled)
            {
                OperationCompleted?.Invoke(false, "Operation cancelled");
            }
            else
            {
                var result = e.Result as OnityResult;
                OperationCompleted?.Invoke(result.Success, result.Message);
            }
        }

        public void CancelOperation()
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
        }

        private class OnityOperation
        {
            public OnityOperationType Type { get; set; }
            public string Room { get; set; }
            public DateTime EndDate { get; set; }
        }

        private class OnityResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string RoomNumber { get; set; }
        }

        private enum OnityOperationType
        {
            CreateCard,
            CheckoutCard,
            ReadCard
        }
    }
}
