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
        private async void InitializeComponent()
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

            Button asyncButton = new Button()
            {
                Location = new Point(10, 50),
                Text = "ASYNC"
            };

            Button syncButton = new Button()
            {
                Location = new Point(50, 50),
                Text = "SYNC"
            };

            //Blocking v Non-Blocking code.
            asyncButton.Click += WebTask.PerformComplicatedTaskAsync();
            syncButton.Click += WebTask.PerformComplicatedTaskSync();


            //Performing on the UI thread.
            Label label = new Label()
            {
                Location = new Point(100, 100),
                Text = "FETCHING"
            };
            string text = await WebTask.ReturnStringAsync();
            label.Text = text;


            //Continuation token
            //Code above is the same as

            var task = WebTask.ReturnStringAsync();
            task.ContinueWith(t => { label.Text = t.Result; });

            //Callback v Continuation
            WebTask.ReturnString((s) => { label.Text = s; });
            //This operation is now responsible for invoking the continuation.


            //Evaluation
            Task t = WebTask.DemoCompletedAsync();
            Console.WriteLine("Method returned");
            task.Wait();
            Console.WriteLine("Task Completed");

            //Exceptions
            t = WebTask.ThrowError();
            Console.WriteLine(t.Status);
            t.Wait();
            Console.WriteLine(t.Status);



            ResumeLayout(false);
        }

        #endregion
    }
}
