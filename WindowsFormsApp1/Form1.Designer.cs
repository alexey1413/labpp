namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.DataGridView dataGridViewLoans;
        private System.Windows.Forms.DataGridView dataGridViewOperations;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBooks;
        private System.Windows.Forms.TabPage tabPageReaders;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.TabPage tabPageLoans;
        private System.Windows.Forms.TabPage tabPageOperations;
        private System.Windows.Forms.Button buttonBookAdd;
        private System.Windows.Forms.Button buttonBookUpdate;
        private System.Windows.Forms.Button buttonBookDelete;
        private System.Windows.Forms.TextBox textBoxBookName;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Button buttonReaderAdd;
        private System.Windows.Forms.Button buttonReaderUpdate;
        private System.Windows.Forms.Button buttonReaderDelete;
        private System.Windows.Forms.TextBox textBoxReaderName;
        private System.Windows.Forms.TextBox textBoxReaderInfo;
        private System.Windows.Forms.Button buttonEmployeeAdd;
        private System.Windows.Forms.Button buttonEmployeeUpdate;
        private System.Windows.Forms.Button buttonEmployeeDelete;
        private System.Windows.Forms.TextBox textBoxEmployeeName;
        private System.Windows.Forms.TextBox textBoxEmployeeAge;
        private System.Windows.Forms.Button buttonLoanIssue;
        private System.Windows.Forms.Button buttonLoanReturn;
        private System.Windows.Forms.ComboBox comboBoxLoanBook;
        private System.Windows.Forms.ComboBox comboBoxLoanReader;
        private System.Windows.Forms.ComboBox comboBoxLoanEmployee;
        private System.Windows.Forms.Button buttonOperationAdd;
        private System.Windows.Forms.ComboBox comboBoxOperationType;
        private System.Windows.Forms.ComboBox comboBoxOperationBook;
        private System.Windows.Forms.ComboBox comboBoxOperationEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewLoans = new System.Windows.Forms.DataGridView();
            this.dataGridViewOperations = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBooks = new System.Windows.Forms.TabPage();
            this.tabPageReaders = new System.Windows.Forms.TabPage();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.tabPageLoans = new System.Windows.Forms.TabPage();
            this.tabPageOperations = new System.Windows.Forms.TabPage();
            this.buttonBookAdd = new System.Windows.Forms.Button();
            this.buttonBookUpdate = new System.Windows.Forms.Button();
            this.buttonBookDelete = new System.Windows.Forms.Button();
            this.textBoxBookName = new System.Windows.Forms.TextBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonReaderAdd = new System.Windows.Forms.Button();
            this.buttonReaderUpdate = new System.Windows.Forms.Button();
            this.buttonReaderDelete = new System.Windows.Forms.Button();
            this.textBoxReaderName = new System.Windows.Forms.TextBox();
            this.textBoxReaderInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEmployeeAdd = new System.Windows.Forms.Button();
            this.buttonEmployeeUpdate = new System.Windows.Forms.Button();
            this.buttonEmployeeDelete = new System.Windows.Forms.Button();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.textBoxEmployeeAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoanIssue = new System.Windows.Forms.Button();
            this.buttonLoanReturn = new System.Windows.Forms.Button();
            this.comboBoxLoanBook = new System.Windows.Forms.ComboBox();
            this.comboBoxLoanReader = new System.Windows.Forms.ComboBox();
            this.comboBoxLoanEmployee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonOperationAdd = new System.Windows.Forms.Button();
            this.comboBoxOperationType = new System.Windows.Forms.ComboBox();
            this.comboBoxOperationBook = new System.Windows.Forms.ComboBox();
            this.comboBoxOperationEmployee = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageBooks.SuspendLayout();
            this.tabPageReaders.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            this.tabPageLoans.SuspendLayout();
            this.tabPageOperations.SuspendLayout();
            this.SuspendLayout();

            // dataGridViewBooks
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewBooks.TabIndex = 0;

            // dataGridViewReaders
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewReaders.TabIndex = 0;

            // dataGridViewEmployees
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewEmployees.TabIndex = 0;

            // dataGridViewLoans
            this.dataGridViewLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoans.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewLoans.Name = "dataGridViewLoans";
            this.dataGridViewLoans.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewLoans.TabIndex = 0;

            // dataGridViewOperations
            this.dataGridViewOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperations.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewOperations.Name = "dataGridViewOperations";
            this.dataGridViewOperations.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewOperations.TabIndex = 0;

            // tabControl1
            this.tabControl1.Controls.Add(this.tabPageBooks);
            this.tabControl1.Controls.Add(this.tabPageReaders);
            this.tabControl1.Controls.Add(this.tabPageEmployees);
            this.tabControl1.Controls.Add(this.tabPageLoans);
            this.tabControl1.Controls.Add(this.tabPageOperations);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 600);
            this.tabControl1.TabIndex = 0;

            // tabPageBooks
            this.tabPageBooks.Controls.Add(this.dataGridViewBooks);
            this.tabPageBooks.Controls.Add(this.textBoxBookName);
            this.tabPageBooks.Controls.Add(this.comboBoxGenre);
            this.tabPageBooks.Controls.Add(this.label1);
            this.tabPageBooks.Controls.Add(this.label2);
            this.tabPageBooks.Controls.Add(this.buttonBookAdd);
            this.tabPageBooks.Controls.Add(this.buttonBookUpdate);
            this.tabPageBooks.Controls.Add(this.buttonBookDelete);
            this.tabPageBooks.Location = new System.Drawing.Point(4, 29);
            this.tabPageBooks.Name = "tabPageBooks";
            this.tabPageBooks.Size = new System.Drawing.Size(1092, 567);
            this.tabPageBooks.TabIndex = 0;
            this.tabPageBooks.Text = "Книги";
            this.tabPageBooks.UseVisualStyleBackColor = true;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";

            this.textBoxBookName.Location = new System.Drawing.Point(770, 37);
            this.textBoxBookName.Name = "textBoxBookName";
            this.textBoxBookName.Size = new System.Drawing.Size(250, 27);
            this.textBoxBookName.TabIndex = 1;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Жанр:";

            this.comboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Location = new System.Drawing.Point(770, 77);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(250, 28);
            this.comboBoxGenre.TabIndex = 3;

            this.buttonBookAdd.Location = new System.Drawing.Point(680, 130);
            this.buttonBookAdd.Name = "buttonBookAdd";
            this.buttonBookAdd.Size = new System.Drawing.Size(120, 45);
            this.buttonBookAdd.TabIndex = 4;
            this.buttonBookAdd.Text = "Добавить";
            this.buttonBookAdd.UseVisualStyleBackColor = true;
            this.buttonBookAdd.Click += new System.EventHandler(this.buttonBookAdd_Click);

            this.buttonBookUpdate.Location = new System.Drawing.Point(820, 130);
            this.buttonBookUpdate.Name = "buttonBookUpdate";
            this.buttonBookUpdate.Size = new System.Drawing.Size(120, 45);
            this.buttonBookUpdate.TabIndex = 5;
            this.buttonBookUpdate.Text = "Изменить";
            this.buttonBookUpdate.UseVisualStyleBackColor = true;
            this.buttonBookUpdate.Click += new System.EventHandler(this.buttonBookUpdate_Click);

            this.buttonBookDelete.Location = new System.Drawing.Point(680, 190);
            this.buttonBookDelete.Name = "buttonBookDelete";
            this.buttonBookDelete.Size = new System.Drawing.Size(260, 45);
            this.buttonBookDelete.TabIndex = 6;
            this.buttonBookDelete.Text = "Удалить";
            this.buttonBookDelete.UseVisualStyleBackColor = true;
            this.buttonBookDelete.Click += new System.EventHandler(this.buttonBookDelete_Click);

            // tabPageReaders
            this.tabPageReaders.Controls.Add(this.dataGridViewReaders);
            this.tabPageReaders.Controls.Add(this.textBoxReaderName);
            this.tabPageReaders.Controls.Add(this.textBoxReaderInfo);
            this.tabPageReaders.Controls.Add(this.label3);
            this.tabPageReaders.Controls.Add(this.buttonReaderAdd);
            this.tabPageReaders.Controls.Add(this.buttonReaderUpdate);
            this.tabPageReaders.Controls.Add(this.buttonReaderDelete);
            this.tabPageReaders.Location = new System.Drawing.Point(4, 29);
            this.tabPageReaders.Name = "tabPageReaders";
            this.tabPageReaders.Size = new System.Drawing.Size(1092, 567);
            this.tabPageReaders.TabIndex = 1;
            this.tabPageReaders.Text = "Читатели";
            this.tabPageReaders.UseVisualStyleBackColor = true;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "ФИО:";

            this.textBoxReaderName.Location = new System.Drawing.Point(770, 37);
            this.textBoxReaderName.Name = "textBoxReaderName";
            this.textBoxReaderName.Size = new System.Drawing.Size(250, 27);
            this.textBoxReaderName.TabIndex = 1;

            this.textBoxReaderInfo.Location = new System.Drawing.Point(680, 80);
            this.textBoxReaderInfo.Multiline = true;
            this.textBoxReaderInfo.Name = "textBoxReaderInfo";
            this.textBoxReaderInfo.Size = new System.Drawing.Size(340, 60);
            this.textBoxReaderInfo.TabIndex = 2;

            this.buttonReaderAdd.Location = new System.Drawing.Point(680, 160);
            this.buttonReaderAdd.Name = "buttonReaderAdd";
            this.buttonReaderAdd.Size = new System.Drawing.Size(120, 45);
            this.buttonReaderAdd.TabIndex = 3;
            this.buttonReaderAdd.Text = "Добавить";
            this.buttonReaderAdd.UseVisualStyleBackColor = true;
            this.buttonReaderAdd.Click += new System.EventHandler(this.buttonReaderAdd_Click);

            this.buttonReaderUpdate.Location = new System.Drawing.Point(820, 160);
            this.buttonReaderUpdate.Name = "buttonReaderUpdate";
            this.buttonReaderUpdate.Size = new System.Drawing.Size(120, 45);
            this.buttonReaderUpdate.TabIndex = 4;
            this.buttonReaderUpdate.Text = "Изменить";
            this.buttonReaderUpdate.UseVisualStyleBackColor = true;
            this.buttonReaderUpdate.Click += new System.EventHandler(this.buttonReaderUpdate_Click);

            this.buttonReaderDelete.Location = new System.Drawing.Point(680, 220);
            this.buttonReaderDelete.Name = "buttonReaderDelete";
            this.buttonReaderDelete.Size = new System.Drawing.Size(260, 45);
            this.buttonReaderDelete.TabIndex = 5;
            this.buttonReaderDelete.Text = "Удалить";
            this.buttonReaderDelete.UseVisualStyleBackColor = true;
            this.buttonReaderDelete.Click += new System.EventHandler(this.buttonReaderDelete_Click);

            // tabPageEmployees
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Controls.Add(this.textBoxEmployeeName);
            this.tabPageEmployees.Controls.Add(this.textBoxEmployeeAge);
            this.tabPageEmployees.Controls.Add(this.label4);
            this.tabPageEmployees.Controls.Add(this.buttonEmployeeAdd);
            this.tabPageEmployees.Controls.Add(this.buttonEmployeeUpdate);
            this.tabPageEmployees.Controls.Add(this.buttonEmployeeDelete);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 29);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Size = new System.Drawing.Size(1092, 567);
            this.tabPageEmployees.TabIndex = 2;
            this.tabPageEmployees.Text = "Сотрудники";
            this.tabPageEmployees.UseVisualStyleBackColor = true;

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "ФИО:";

            this.textBoxEmployeeName.Location = new System.Drawing.Point(770, 37);
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.Size = new System.Drawing.Size(250, 27);
            this.textBoxEmployeeName.TabIndex = 1;

            this.textBoxEmployeeAge.Location = new System.Drawing.Point(680, 80);
            this.textBoxEmployeeAge.Name = "textBoxEmployeeAge";
            this.textBoxEmployeeAge.Size = new System.Drawing.Size(100, 27);
            this.textBoxEmployeeAge.TabIndex = 2;

            this.buttonEmployeeAdd.Location = new System.Drawing.Point(680, 130);
            this.buttonEmployeeAdd.Name = "buttonEmployeeAdd";
            this.buttonEmployeeAdd.Size = new System.Drawing.Size(120, 45);
            this.buttonEmployeeAdd.TabIndex = 3;
            this.buttonEmployeeAdd.Text = "Добавить";
            this.buttonEmployeeAdd.UseVisualStyleBackColor = true;
            this.buttonEmployeeAdd.Click += new System.EventHandler(this.buttonEmployeeAdd_Click);

            this.buttonEmployeeUpdate.Location = new System.Drawing.Point(820, 130);
            this.buttonEmployeeUpdate.Name = "buttonEmployeeUpdate";
            this.buttonEmployeeUpdate.Size = new System.Drawing.Size(120, 45);
            this.buttonEmployeeUpdate.TabIndex = 4;
            this.buttonEmployeeUpdate.Text = "Изменить";
            this.buttonEmployeeUpdate.UseVisualStyleBackColor = true;
            this.buttonEmployeeUpdate.Click += new System.EventHandler(this.buttonEmployeeUpdate_Click);

            this.buttonEmployeeDelete.Location = new System.Drawing.Point(680, 190);
            this.buttonEmployeeDelete.Name = "buttonEmployeeDelete";
            this.buttonEmployeeDelete.Size = new System.Drawing.Size(260, 45);
            this.buttonEmployeeDelete.TabIndex = 5;
            this.buttonEmployeeDelete.Text = "Удалить";
            this.buttonEmployeeDelete.UseVisualStyleBackColor = true;
            this.buttonEmployeeDelete.Click += new System.EventHandler(this.buttonEmployeeDelete_Click);

            // tabPageLoans
            this.tabPageLoans.Controls.Add(this.dataGridViewLoans);
            this.tabPageLoans.Controls.Add(this.comboBoxLoanBook);
            this.tabPageLoans.Controls.Add(this.comboBoxLoanReader);
            this.tabPageLoans.Controls.Add(this.comboBoxLoanEmployee);
            this.tabPageLoans.Controls.Add(this.label5);
            this.tabPageLoans.Controls.Add(this.buttonLoanIssue);
            this.tabPageLoans.Controls.Add(this.buttonLoanReturn);
            this.tabPageLoans.Location = new System.Drawing.Point(4, 29);
            this.tabPageLoans.Name = "tabPageLoans";
            this.tabPageLoans.Size = new System.Drawing.Size(1092, 567);
            this.tabPageLoans.TabIndex = 3;
            this.tabPageLoans.Text = "Выдача книг";
            this.tabPageLoans.UseVisualStyleBackColor = true;

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(680, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Книга:";

            this.comboBoxLoanBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoanBook.FormattingEnabled = true;
            this.comboBoxLoanBook.Location = new System.Drawing.Point(770, 37);
            this.comboBoxLoanBook.Name = "comboBoxLoanBook";
            this.comboBoxLoanBook.Size = new System.Drawing.Size(250, 28);
            this.comboBoxLoanBook.TabIndex = 1;

            this.comboBoxLoanReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoanReader.FormattingEnabled = true;
            this.comboBoxLoanReader.Location = new System.Drawing.Point(770, 77);
            this.comboBoxLoanReader.Name = "comboBoxLoanReader";
            this.comboBoxLoanReader.Size = new System.Drawing.Size(250, 28);
            this.comboBoxLoanReader.TabIndex = 2;

            this.comboBoxLoanEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoanEmployee.FormattingEnabled = true;
            this.comboBoxLoanEmployee.Location = new System.Drawing.Point(770, 117);
            this.comboBoxLoanEmployee.Name = "comboBoxLoanEmployee";
            this.comboBoxLoanEmployee.Size = new System.Drawing.Size(250, 28);
            this.comboBoxLoanEmployee.TabIndex = 3;

            this.buttonLoanIssue.Location = new System.Drawing.Point(680, 170);
            this.buttonLoanIssue.Name = "buttonLoanIssue";
            this.buttonLoanIssue.Size = new System.Drawing.Size(120, 45);
            this.buttonLoanIssue.TabIndex = 4;
            this.buttonLoanIssue.Text = "Выдать";
            this.buttonLoanIssue.UseVisualStyleBackColor = true;
            this.buttonLoanIssue.Click += new System.EventHandler(this.buttonLoanIssue_Click);

            this.buttonLoanReturn.Location = new System.Drawing.Point(820, 170);
            this.buttonLoanReturn.Name = "buttonLoanReturn";
            this.buttonLoanReturn.Size = new System.Drawing.Size(120, 45);
            this.buttonLoanReturn.TabIndex = 5;
            this.buttonLoanReturn.Text = "Вернуть";
            this.buttonLoanReturn.UseVisualStyleBackColor = true;
            this.buttonLoanReturn.Click += new System.EventHandler(this.buttonLoanReturn_Click);

            // tabPageOperations
            this.tabPageOperations.Controls.Add(this.dataGridViewOperations);
            this.tabPageOperations.Controls.Add(this.comboBoxOperationType);
            this.tabPageOperations.Controls.Add(this.comboBoxOperationBook);
            this.tabPageOperations.Controls.Add(this.comboBoxOperationEmployee);
            this.tabPageOperations.Controls.Add(this.label6);
            this.tabPageOperations.Controls.Add(this.buttonOperationAdd);
            this.tabPageOperations.Location = new System.Drawing.Point(4, 29);
            this.tabPageOperations.Name = "tabPageOperations";
            this.tabPageOperations.Size = new System.Drawing.Size(1092, 567);
            this.tabPageOperations.TabIndex = 4;
            this.tabPageOperations.Text = "Внутренние операции";
            this.tabPageOperations.UseVisualStyleBackColor = true;

            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Книга:";

            this.comboBoxOperationBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperationBook.FormattingEnabled = true;
            this.comboBoxOperationBook.Location = new System.Drawing.Point(770, 37);
            this.comboBoxOperationBook.Name = "comboBoxOperationBook";
            this.comboBoxOperationBook.Size = new System.Drawing.Size(250, 28);
            this.comboBoxOperationBook.TabIndex = 1;

            this.comboBoxOperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperationType.FormattingEnabled = true;
            this.comboBoxOperationType.Items.AddRange(new object[] { "Списание", "Ремонт", "Инвентаризация", "Перемещение" });
            this.comboBoxOperationType.Location = new System.Drawing.Point(770, 77);
            this.comboBoxOperationType.Name = "comboBoxOperationType";
            this.comboBoxOperationType.Size = new System.Drawing.Size(250, 28);
            this.comboBoxOperationType.TabIndex = 2;

            this.comboBoxOperationEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperationEmployee.FormattingEnabled = true;
            this.comboBoxOperationEmployee.Location = new System.Drawing.Point(770, 117);
            this.comboBoxOperationEmployee.Name = "comboBoxOperationEmployee";
            this.comboBoxOperationEmployee.Size = new System.Drawing.Size(250, 28);
            this.comboBoxOperationEmployee.TabIndex = 3;

            this.buttonOperationAdd.Location = new System.Drawing.Point(680, 170);
            this.buttonOperationAdd.Name = "buttonOperationAdd";
            this.buttonOperationAdd.Size = new System.Drawing.Size(260, 45);
            this.buttonOperationAdd.TabIndex = 4;
            this.buttonOperationAdd.Text = "Добавить операцию";
            this.buttonOperationAdd.UseVisualStyleBackColor = true;
            this.buttonOperationAdd.Click += new System.EventHandler(this.buttonOperationAdd_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Библиотечная система";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageBooks.ResumeLayout(false);
            this.tabPageBooks.PerformLayout();
            this.tabPageReaders.ResumeLayout(false);
            this.tabPageReaders.PerformLayout();
            this.tabPageEmployees.ResumeLayout(false);
            this.tabPageEmployees.PerformLayout();
            this.tabPageLoans.ResumeLayout(false);
            this.tabPageLoans.PerformLayout();
            this.tabPageOperations.ResumeLayout(false);
            this.tabPageOperations.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}