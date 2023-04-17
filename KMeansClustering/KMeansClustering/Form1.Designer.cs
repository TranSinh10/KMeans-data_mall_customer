namespace KMeansClustering
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
            loadDataButton = new Button();
            clusterButton = new Button();
            dataGridView1 = new DataGridView();
            numClustersTextBox = new TextBox();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // loadDataButton
            // 
            loadDataButton.BackColor = Color.FromArgb(255, 128, 128);
            loadDataButton.Location = new Point(33, 43);
            loadDataButton.Name = "loadDataButton";
            loadDataButton.Size = new Size(75, 23);
            loadDataButton.TabIndex = 0;
            loadDataButton.Text = "Load Data";
            loadDataButton.UseVisualStyleBackColor = false;
            loadDataButton.Click += loadDataButton_Click;
            // 
            // clusterButton
            // 
            clusterButton.BackColor = Color.FromArgb(255, 128, 128);
            clusterButton.Location = new Point(33, 107);
            clusterButton.Name = "clusterButton";
            clusterButton.Size = new Size(75, 23);
            clusterButton.TabIndex = 1;
            clusterButton.Text = "Clustering";
            clusterButton.UseVisualStyleBackColor = false;
            clusterButton.Click += clusterButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 267);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(728, 171);
            dataGridView1.TabIndex = 3;
            // 
            // numClustersTextBox
            // 
            numClustersTextBox.Location = new Point(123, 44);
            numClustersTextBox.Name = "numClustersTextBox";
            numClustersTextBox.Size = new Size(78, 23);
            numClustersTextBox.TabIndex = 4;
            numClustersTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.White;
            plotView1.Location = new Point(287, 43);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(483, 218);
            plotView1.TabIndex = 5;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(123, 9);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 6;
            label1.Text = "Số cụm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(473, 9);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 7;
            label2.Text = "Kết quả phân cụm";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(plotView1);
            Controls.Add(numClustersTextBox);
            Controls.Add(dataGridView1);
            Controls.Add(clusterButton);
            Controls.Add(loadDataButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadDataButton;
        private Button clusterButton;
        private DataGridView dataGridView1;
        private TextBox numClustersTextBox;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label label1;
        private Label label2;
    }
}