namespace BlockingTaskQueue
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initGroupBox = new System.Windows.Forms.GroupBox();
            this.startDequeueButton = new System.Windows.Forms.Button();
            this.dequeueThreadsTextBox = new System.Windows.Forms.TextBox();
            this.dequeueThreadsLabel = new System.Windows.Forms.Label();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.queueButton = new System.Windows.Forms.Button();
            this.tasksPerThreadTextBox = new System.Windows.Forms.TextBox();
            this.tasksPerThreadLabel = new System.Windows.Forms.Label();
            this.numQueueThreadslabel = new System.Windows.Forms.Label();
            this.queueThreadsTextBox = new System.Windows.Forms.TextBox();
            this.userInputPanel = new System.Windows.Forms.Panel();
            this.operand2TextBox = new System.Windows.Forms.TextBox();
            this.operand2Label = new System.Windows.Forms.Label();
            this.operand1Label = new System.Windows.Forms.Label();
            this.operand1TextBox = new System.Windows.Forms.TextBox();
            this.tasksComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.outputsGroupBox = new System.Windows.Forms.GroupBox();
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.initGroupBox.SuspendLayout();
            this.inputGroupBox.SuspendLayout();
            this.userInputPanel.SuspendLayout();
            this.outputsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // initGroupBox
            // 
            this.initGroupBox.Controls.Add(this.startDequeueButton);
            this.initGroupBox.Controls.Add(this.dequeueThreadsTextBox);
            this.initGroupBox.Controls.Add(this.dequeueThreadsLabel);
            this.initGroupBox.Location = new System.Drawing.Point(12, 12);
            this.initGroupBox.Name = "initGroupBox";
            this.initGroupBox.Size = new System.Drawing.Size(681, 55);
            this.initGroupBox.TabIndex = 1;
            this.initGroupBox.TabStop = false;
            this.initGroupBox.Text = "Initialization";
            // 
            // startDequeueButton
            // 
            this.startDequeueButton.Location = new System.Drawing.Point(587, 16);
            this.startDequeueButton.Name = "startDequeueButton";
            this.startDequeueButton.Size = new System.Drawing.Size(75, 23);
            this.startDequeueButton.TabIndex = 2;
            this.startDequeueButton.Text = "Start";
            this.startDequeueButton.UseVisualStyleBackColor = true;
            this.startDequeueButton.Click += new System.EventHandler(this.startDequeueButton_Click);
            // 
            // dequeueThreadsTextBox
            // 
            this.dequeueThreadsTextBox.Location = new System.Drawing.Point(192, 13);
            this.dequeueThreadsTextBox.Name = "dequeueThreadsTextBox";
            this.dequeueThreadsTextBox.Size = new System.Drawing.Size(100, 20);
            this.dequeueThreadsTextBox.TabIndex = 1;
            // 
            // dequeueThreadsLabel
            // 
            this.dequeueThreadsLabel.AutoSize = true;
            this.dequeueThreadsLabel.Location = new System.Drawing.Point(6, 16);
            this.dequeueThreadsLabel.Name = "dequeueThreadsLabel";
            this.dequeueThreadsLabel.Size = new System.Drawing.Size(180, 13);
            this.dequeueThreadsLabel.TabIndex = 0;
            this.dequeueThreadsLabel.Text = "Number of de-queue worker threads:";
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.queueButton);
            this.inputGroupBox.Controls.Add(this.tasksPerThreadTextBox);
            this.inputGroupBox.Controls.Add(this.tasksPerThreadLabel);
            this.inputGroupBox.Controls.Add(this.numQueueThreadslabel);
            this.inputGroupBox.Controls.Add(this.queueThreadsTextBox);
            this.inputGroupBox.Controls.Add(this.userInputPanel);
            this.inputGroupBox.Controls.Add(this.tasksComboBox);
            this.inputGroupBox.Controls.Add(this.button1);
            this.inputGroupBox.Controls.Add(this.label1);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 73);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(302, 330);
            this.inputGroupBox.TabIndex = 2;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input";
            // 
            // queueButton
            // 
            this.queueButton.Location = new System.Drawing.Point(111, 251);
            this.queueButton.Name = "queueButton";
            this.queueButton.Size = new System.Drawing.Size(75, 23);
            this.queueButton.TabIndex = 9;
            this.queueButton.Text = "Queue";
            this.queueButton.UseVisualStyleBackColor = true;
            this.queueButton.Click += new System.EventHandler(this.queueButton_Click);
            // 
            // tasksPerThreadTextBox
            // 
            this.tasksPerThreadTextBox.Location = new System.Drawing.Point(227, 210);
            this.tasksPerThreadTextBox.Name = "tasksPerThreadTextBox";
            this.tasksPerThreadTextBox.Size = new System.Drawing.Size(62, 20);
            this.tasksPerThreadTextBox.TabIndex = 8;
            // 
            // tasksPerThreadLabel
            // 
            this.tasksPerThreadLabel.AutoSize = true;
            this.tasksPerThreadLabel.Location = new System.Drawing.Point(6, 213);
            this.tasksPerThreadLabel.Name = "tasksPerThreadLabel";
            this.tasksPerThreadLabel.Size = new System.Drawing.Size(133, 13);
            this.tasksPerThreadLabel.TabIndex = 7;
            this.tasksPerThreadLabel.Text = "Task instances per thread:";
            // 
            // numQueueThreadslabel
            // 
            this.numQueueThreadslabel.AutoSize = true;
            this.numQueueThreadslabel.Location = new System.Drawing.Point(6, 167);
            this.numQueueThreadslabel.Name = "numQueueThreadslabel";
            this.numQueueThreadslabel.Size = new System.Drawing.Size(173, 13);
            this.numQueueThreadslabel.TabIndex = 6;
            this.numQueueThreadslabel.Text = "Number of queuing worker threads:";
            // 
            // queueThreadsTextBox
            // 
            this.queueThreadsTextBox.Location = new System.Drawing.Point(227, 167);
            this.queueThreadsTextBox.Name = "queueThreadsTextBox";
            this.queueThreadsTextBox.Size = new System.Drawing.Size(62, 20);
            this.queueThreadsTextBox.TabIndex = 5;
            // 
            // userInputPanel
            // 
            this.userInputPanel.Controls.Add(this.operand2TextBox);
            this.userInputPanel.Controls.Add(this.operand2Label);
            this.userInputPanel.Controls.Add(this.operand1Label);
            this.userInputPanel.Controls.Add(this.operand1TextBox);
            this.userInputPanel.Location = new System.Drawing.Point(9, 49);
            this.userInputPanel.Name = "userInputPanel";
            this.userInputPanel.Size = new System.Drawing.Size(283, 100);
            this.userInputPanel.TabIndex = 4;
            // 
            // operand2TextBox
            // 
            this.operand2TextBox.Location = new System.Drawing.Point(105, 45);
            this.operand2TextBox.Name = "operand2TextBox";
            this.operand2TextBox.Size = new System.Drawing.Size(175, 20);
            this.operand2TextBox.TabIndex = 4;
            // 
            // operand2Label
            // 
            this.operand2Label.AutoSize = true;
            this.operand2Label.Location = new System.Drawing.Point(19, 52);
            this.operand2Label.Name = "operand2Label";
            this.operand2Label.Size = new System.Drawing.Size(52, 13);
            this.operand2Label.TabIndex = 3;
            this.operand2Label.Text = "operand2";
            // 
            // operand1Label
            // 
            this.operand1Label.AutoSize = true;
            this.operand1Label.Location = new System.Drawing.Point(19, 15);
            this.operand1Label.Name = "operand1Label";
            this.operand1Label.Size = new System.Drawing.Size(52, 13);
            this.operand1Label.TabIndex = 2;
            this.operand1Label.Text = "operand1";
            // 
            // operand1TextBox
            // 
            this.operand1TextBox.Location = new System.Drawing.Point(105, 15);
            this.operand1TextBox.Name = "operand1TextBox";
            this.operand1TextBox.Size = new System.Drawing.Size(175, 20);
            this.operand1TextBox.TabIndex = 1;
            // 
            // tasksComboBox
            // 
            this.tasksComboBox.FormattingEnabled = true;
            this.tasksComboBox.Location = new System.Drawing.Point(69, 13);
            this.tasksComboBox.Name = "tasksComboBox";
            this.tasksComboBox.Size = new System.Drawing.Size(169, 21);
            this.tasksComboBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task type:";
            // 
            // outputsGroupBox
            // 
            this.outputsGroupBox.Controls.Add(this.outputListBox);
            this.outputsGroupBox.Controls.Add(this.button3);
            this.outputsGroupBox.Location = new System.Drawing.Point(320, 73);
            this.outputsGroupBox.Name = "outputsGroupBox";
            this.outputsGroupBox.Size = new System.Drawing.Size(373, 330);
            this.outputsGroupBox.TabIndex = 3;
            this.outputsGroupBox.TabStop = false;
            this.outputsGroupBox.Text = "Outputs";
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.Location = new System.Drawing.Point(6, 19);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(349, 303);
            this.outputListBox.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 417);
            this.Controls.Add(this.outputsGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.initGroupBox);
            this.Name = "MainForm";
            this.Text = "Blocking Queue Simulator";
            this.initGroupBox.ResumeLayout(false);
            this.initGroupBox.PerformLayout();
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.userInputPanel.ResumeLayout(false);
            this.userInputPanel.PerformLayout();
            this.outputsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox initGroupBox;
        private System.Windows.Forms.Button startDequeueButton;
        private System.Windows.Forms.TextBox dequeueThreadsTextBox;
        private System.Windows.Forms.Label dequeueThreadsLabel;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.TextBox tasksPerThreadTextBox;
        private System.Windows.Forms.Label tasksPerThreadLabel;
        private System.Windows.Forms.Label numQueueThreadslabel;
        private System.Windows.Forms.TextBox queueThreadsTextBox;
        private System.Windows.Forms.Panel userInputPanel;
        private System.Windows.Forms.TextBox operand2TextBox;
        private System.Windows.Forms.Label operand2Label;
        private System.Windows.Forms.Label operand1Label;
        private System.Windows.Forms.TextBox operand1TextBox;
        private System.Windows.Forms.ComboBox tasksComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button queueButton;
        private System.Windows.Forms.GroupBox outputsGroupBox;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.Button button3;
    }
}

