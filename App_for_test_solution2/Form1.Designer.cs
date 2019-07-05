namespace App_for_test_solution2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TestName = new System.Windows.Forms.Label();
            this.beginButton = new System.Windows.Forms.Button();
            this.TestOptions = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.repeatButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.TimeMin = new System.Windows.Forms.Label();
            this.TimeSec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TestName
            // 
            this.TestName.Font = new System.Drawing.Font("Calibri", 24F);
            this.TestName.Location = new System.Drawing.Point(40, 21);
            this.TestName.Name = "TestName";
            this.TestName.Size = new System.Drawing.Size(729, 94);
            this.TestName.TabIndex = 1;
            this.TestName.Text = "Тест по инструментальным средствам информационных систем";
            this.TestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TestName.UseCompatibleTextRendering = true;
            this.TestName.UseMnemonic = false;
            // 
            // beginButton
            // 
            this.beginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginButton.Location = new System.Drawing.Point(256, 229);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(289, 79);
            this.beginButton.TabIndex = 2;
            this.beginButton.Text = "Запуск теста";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // TestOptions
            // 
            this.TestOptions.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestOptions.Location = new System.Drawing.Point(58, 116);
            this.TestOptions.Name = "TestOptions";
            this.TestOptions.Size = new System.Drawing.Size(693, 89);
            this.TestOptions.TabIndex = 3;
            this.TestOptions.Text = "15 вопросов; 30 минут";
            this.TestOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(22, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 89);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(406, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(370, 89);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(22, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(370, 89);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(406, 249);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(370, 89);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(256, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(289, 59);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // endButton
            // 
            this.endButton.BackColor = System.Drawing.SystemColors.Control;
            this.endButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endButton.Location = new System.Drawing.Point(255, 359);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(289, 59);
            this.endButton.TabIndex = 9;
            this.endButton.Text = "button6";
            this.endButton.UseVisualStyleBackColor = false;
            this.endButton.Visible = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.Control;
            this.closeButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(406, 271);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(226, 44);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Выход из теста";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.BackColor = System.Drawing.SystemColors.Control;
            this.repeatButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatButton.Location = new System.Drawing.Point(166, 271);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(226, 44);
            this.repeatButton.TabIndex = 11;
            this.repeatButton.Text = "Повторить попытку";
            this.repeatButton.UseVisualStyleBackColor = false;
            this.repeatButton.Visible = false;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time
            // 
            this.Time.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time.Location = new System.Drawing.Point(582, 377);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(66, 22);
            this.Time.TabIndex = 12;
            this.Time.Text = "Время:";
            this.Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Time.Visible = false;
            // 
            // TimeMin
            // 
            this.TimeMin.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeMin.Location = new System.Drawing.Point(644, 377);
            this.TimeMin.Name = "TimeMin";
            this.TimeMin.Size = new System.Drawing.Size(37, 23);
            this.TimeMin.TabIndex = 13;
            this.TimeMin.Text = "30:";
            this.TimeMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimeMin.Visible = false;
            // 
            // TimeSec
            // 
            this.TimeSec.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeSec.Location = new System.Drawing.Point(673, 377);
            this.TimeSec.Name = "TimeSec";
            this.TimeSec.Size = new System.Drawing.Size(32, 23);
            this.TimeSec.TabIndex = 14;
            this.TimeSec.Text = "00";
            this.TimeSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimeSec.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimeSec);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.TestName);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.TestOptions);
            this.Controls.Add(this.TimeMin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TestName;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Label TestOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button repeatButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label TimeMin;
        private System.Windows.Forms.Label TimeSec;
    }
}

