using System.Diagnostics;

namespace AsyncAwait
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;

            // Async vs Sync buttons
            Button asyncButton = new Button()
            {
                Location = new Point(10, 50),
                Text = "ASYNC"
            };
            asyncButton.Click += WebTask.PerformComplicatedTaskAsync;

            Button syncButton = new Button()
            {
                Location = new Point(100, 50),
                Text = "SYNC"
            };
            syncButton.Click += WebTask.PerformComplicatedTaskSync;

            // Experiment buttons
            Button uiThreadButton = new Button()
            {
                Location = new Point(10, 100),
                Text = "UI Thread Demo"
            };
            uiThreadButton.Click += UiThreadDemo_Click;

            Button continuationButton = new Button()
            {
                Location = new Point(10, 150),
                Text = "Continuation Demo"
            };
            continuationButton.Click += ContinuationDemo_Click;

            Button callbackButton = new Button()
            {
                Location = new Point(10, 200),
                Text = "Callback Demo"
            };
            callbackButton.Click += CallbackDemo_Click;

            Button evaluationButton = new Button()
            {
                Location = new Point(10, 250),
                Text = "Evaluation Demo"
            };
            evaluationButton.Click += EvaluationDemo_Click;

            Button exceptionButton = new Button()
            {
                Location = new Point(10, 300),
                Text = "Exception Demo"
            };
            exceptionButton.Click += ExceptionDemo_Click;

            Button cancellationButton = new Button()
            {
                Location = new Point(10, 350),
                Text = "Cancellation Demo"
            };
            cancellationButton.Click += CancellationDemo_Click;

            Controls.AddRange(new Control[]
            {
        asyncButton, syncButton,
        uiThreadButton, continuationButton, callbackButton,
        evaluationButton, exceptionButton, cancellationButton
            });

            ResumeLayout(false);
        }


        #endregion

        private async void UiThreadDemo_Click(object sender, EventArgs e)
        {
            Label label = new Label()
            {
                Location = new Point(200, 100),
                Text = "FETCHING"
            };
            Controls.Add(label);

            string text = await WebTask.ReturnStringAsync();
            label.Text = text;
        }

        private void ContinuationDemo_Click(object sender, EventArgs e)
        {
            Label label = new Label()
            {
                Location = new Point(200, 150),
                Text = "FETCHING"
            };
            Controls.Add(label);

            var task = WebTask.ReturnStringAsync();
            task.ContinueWith(t => Invoke(() => label.Text = t.Result));
        }

        private void CallbackDemo_Click(object sender, EventArgs e)
        {
            Label label = new Label()
            {
                Location = new Point(200, 200),
                Text = "FETCHING"
            };
            Controls.Add(label);

            WebTask.ReturnString(s => Invoke(() => label.Text = s));
        }

        private async void EvaluationDemo_Click(object sender, EventArgs e)
        {
            Task t = WebTask.DemoCompletedAsync();
            Debug.WriteLine("Method returned");
            await t;
            Debug.WriteLine("Task Completed");
        }

        private async void ExceptionDemo_Click(object sender, EventArgs e)
        {
            Task t = WebTask.ThrowError();
            Debug.WriteLine(t.Status);
            try
            {
                await t;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.InnerException?.Message}");
            }
            Debug.WriteLine(t.Status);
        }

        private async void CancellationDemo_Click(object sender, EventArgs e)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Task t = WebTask.CancelTask(token);

            // Cancel after 500ms
            await Task.Delay(500);
            source.Cancel();

            try
            {
                await t;
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Task was cancelled");
            }
            Debug.WriteLine(t.Status.ToString());
        }
    }


}
