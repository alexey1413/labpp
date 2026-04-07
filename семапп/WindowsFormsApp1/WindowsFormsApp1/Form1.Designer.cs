using System.Drawing;
using System.Windows.Forms;

namespace Biblioteka


{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            dataGridViewBooks = new DataGridView();
            tabControl1 = new TabControl();
            tabPageBooks = new TabPage();
            label2 = new Label();
            label1 = new Label();
            buttonBookDelete = new Button();
            buttonBookUpdate = new Button();
            buttonBookAdd = new Button();
            comboBoxGenre = new ComboBox();
            textBoxBookName = new TextBox();
            tabPageReaders = new TabPage();
            label3 = new Label();
            textBoxReaderInfo = new TextBox();
            buttonReaderDelete = new Button();
            buttonReaderUpdate = new Button();
            buttonReaderAdd = new Button();
            textBoxReaderName = new TextBox();
            dataGridViewReaders = new DataGridView();
            tabPageEmployees = new TabPage();
            label4 = new Label();
            textBoxEmployeeAge = new TextBox();
            buttonEmployeeDelete = new Button();
            buttonEmployeeUpdate = new Button();
            buttonEmployeeAdd = new Button();
            textBoxEmployeeName = new TextBox();
            dataGridViewEmployees = new DataGridView();
            tabPageLoans = new TabPage();
            label5 = new Label();
            buttonLoanReturn = new Button();
            buttonLoanIssue = new Button();
            comboBoxLoanBook = new ComboBox();
            comboBoxLoanReader = new ComboBox();
            comboBoxLoanEmployee = new ComboBox();
            dataGridViewLoans = new DataGridView();
            tabPageOperations = new TabPage();
            label6 = new Label();
            buttonOperationAdd = new Button();
            comboBoxOperationType = new ComboBox();
            comboBoxOperationBook = new ComboBox();
            comboBoxOperationEmployee = new ComboBox();
            dataGridViewOperations = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            tabControl1.SuspendLayout();
            tabPageBooks.SuspendLayout();
            tabPageReaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReaders).BeginInit();
            tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            tabPageLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoans).BeginInit();
            tabPageOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).BeginInit();
            SuspendLayout();

            // dataGridViewBooks
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(0, 0);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.Size = new Size(500, 400);
            dataGridViewBooks.TabIndex = 1;

            // tabControl1
            tabControl1.Controls.Add(tabPageBooks);
            tabControl1.Controls.Add(tabPageReaders);
            tabControl1.Controls.Add(tabPageEmployees);
            tabControl1.Controls.Add(tabPageLoans);
            tabControl1.Controls.Add(tabPageOperations);
            tabControl1.Location = new Point(4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 600);
            tabControl1.TabIndex = 2;

            // tabPageBooks - Книги
            tabPageBooks.Controls.Add(label2);
            tabPageBooks.Controls.Add(label1);
            tabPageBooks.Controls.Add(buttonBookDelete);
            tabPageBooks.Controls.Add(buttonBookUpdate);
            tabPageBooks.Controls.Add(buttonBookAdd);
            tabPageBooks.Controls.Add(comboBoxGenre);
            tabPageBooks.Controls.Add(textBoxBookName);
            tabPageBooks.Controls.Add(dataGridViewBooks);
            tabPageBooks.Location = new Point(4, 24);
            tabPageBooks.Name = "tabPageBooks";
            tabPageBooks.Padding = new Padding(3);
            tabPageBooks.Size = new Size(992, 572);
            tabPageBooks.TabIndex = 0;
            tabPageBooks.Text = "Книги";
            tabPageBooks.UseVisualStyleBackColor = true;

            label2.AutoSize = true;
            label2.Location = new Point(550, 380);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 8;
            label2.Text = "Жанр:";

            label1.AutoSize = true;
            label1.Location = new Point(550, 350);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 7;
            label1.Text = "Название:";

            buttonBookDelete.Location = new Point(520, 250);
            buttonBookDelete.Name = "buttonBookDelete";
            buttonBookDelete.Size = new Size(450, 50);
            buttonBookDelete.TabIndex = 6;
            buttonBookDelete.Text = "Удалить книгу";
            buttonBookDelete.UseVisualStyleBackColor = true;

            buttonBookUpdate.Location = new Point(520, 180);
            buttonBookUpdate.Name = "buttonBookUpdate";
            buttonBookUpdate.Size = new Size(450, 50);
            buttonBookUpdate.TabIndex = 5;
            buttonBookUpdate.Text = "Изменить книгу";
            buttonBookUpdate.UseVisualStyleBackColor = true;

            buttonBookAdd.Font = new Font("Segoe UI", 12F);
            buttonBookAdd.Location = new Point(520, 100);
            buttonBookAdd.Name = "buttonBookAdd";
            buttonBookAdd.Size = new Size(450, 60);
            buttonBookAdd.TabIndex = 4;
            buttonBookAdd.Text = "Добавить книгу";
            buttonBookAdd.UseVisualStyleBackColor = true;

            comboBoxGenre.FormattingEnabled = true;
            comboBoxGenre.Location = new Point(650, 377);
            comboBoxGenre.Name = "comboBoxGenre";
            comboBoxGenre.Size = new Size(320, 23);
            comboBoxGenre.TabIndex = 3;

            textBoxBookName.Location = new Point(650, 347);
            textBoxBookName.Name = "textBoxBookName";
            textBoxBookName.Size = new Size(320, 23);
            textBoxBookName.TabIndex = 2;

            // tabPageReaders - Читатели
            tabPageReaders.Controls.Add(label3);
            tabPageReaders.Controls.Add(textBoxReaderInfo);
            tabPageReaders.Controls.Add(buttonReaderDelete);
            tabPageReaders.Controls.Add(buttonReaderUpdate);
            tabPageReaders.Controls.Add(buttonReaderAdd);
            tabPageReaders.Controls.Add(textBoxReaderName);
            tabPageReaders.Controls.Add(dataGridViewReaders);
            tabPageReaders.Location = new Point(4, 24);
            tabPageReaders.Name = "tabPageReaders";
            tabPageReaders.Padding = new Padding(3);
            tabPageReaders.Size = new Size(992, 572);
            tabPageReaders.TabIndex = 1;
            tabPageReaders.Text = "Читатели";
            tabPageReaders.UseVisualStyleBackColor = true;

            label3.AutoSize = true;
            label3.Location = new Point(550, 380);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 8;
            label3.Text = "Личная информ.:";

            textBoxReaderInfo.Location = new Point(650, 377);
            textBoxReaderInfo.Name = "textBoxReaderInfo";
            textBoxReaderInfo.Size = new Size(320, 23);
            textBoxReaderInfo.TabIndex = 7;

            buttonReaderDelete.Location = new Point(520, 250);
            buttonReaderDelete.Name = "buttonReaderDelete";
            buttonReaderDelete.Size = new Size(450, 50);
            buttonReaderDelete.TabIndex = 6;
            buttonReaderDelete.Text = "Удалить читателя";

            buttonReaderUpdate.Location = new Point(520, 180);
            buttonReaderUpdate.Name = "buttonReaderUpdate";
            buttonReaderUpdate.Size = new Size(450, 50);
            buttonReaderUpdate.TabIndex = 5;
            buttonReaderUpdate.Text = "Изменить читателя";

            buttonReaderAdd.Font = new Font("Segoe UI", 12F);
            buttonReaderAdd.Location = new Point(520, 100);
            buttonReaderAdd.Name = "buttonReaderAdd";
            buttonReaderAdd.Size = new Size(450, 60);
            buttonReaderAdd.TabIndex = 4;
            buttonReaderAdd.Text = "Добавить читателя";

            textBoxReaderName.Location = new Point(650, 347);
            textBoxReaderName.Name = "textBoxReaderName";
            textBoxReaderName.Size = new Size(320, 23);
            textBoxReaderName.TabIndex = 2;

            dataGridViewReaders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReaders.Location = new Point(0, 0);
            dataGridViewReaders.Name = "dataGridViewReaders";
            dataGridViewReaders.Size = new Size(500, 400);
            dataGridViewReaders.TabIndex = 1;

            // tabPageEmployees - Сотрудники
            tabPageEmployees.Controls.Add(label4);
            tabPageEmployees.Controls.Add(textBoxEmployeeAge);
            tabPageEmployees.Controls.Add(buttonEmployeeDelete);
            tabPageEmployees.Controls.Add(buttonEmployeeUpdate);
            tabPageEmployees.Controls.Add(buttonEmployeeAdd);
            tabPageEmployees.Controls.Add(textBoxEmployeeName);
            tabPageEmployees.Controls.Add(dataGridViewEmployees);
            tabPageEmployees.Location = new Point(4, 24);
            tabPageEmployees.Name = "tabPageEmployees";
            tabPageEmployees.Size = new Size(992, 572);
            tabPageEmployees.TabIndex = 2;
            tabPageEmployees.Text = "Сотрудники";
            tabPageEmployees.UseVisualStyleBackColor = true;

            label4.AutoSize = true;
            label4.Location = new Point(550, 380);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 8;
            label4.Text = "Возраст:";

            textBoxEmployeeAge.Location = new Point(650, 377);
            textBoxEmployeeAge.Name = "textBoxEmployeeAge";
            textBoxEmployeeAge.Size = new Size(320, 23);
            textBoxEmployeeAge.TabIndex = 7;

            buttonEmployeeDelete.Location = new Point(520, 250);
            buttonEmployeeDelete.Name = "buttonEmployeeDelete";
            buttonEmployeeDelete.Size = new Size(450, 50);
            buttonEmployeeDelete.TabIndex = 6;
            buttonEmployeeDelete.Text = "Удалить сотрудника";

            buttonEmployeeUpdate.Location = new Point(520, 180);
            buttonEmployeeUpdate.Name = "buttonEmployeeUpdate";
            buttonEmployeeUpdate.Size = new Size(450, 50);
            buttonEmployeeUpdate.TabIndex = 5;
            buttonEmployeeUpdate.Text = "Изменить сотрудника";

            buttonEmployeeAdd.Font = new Font("Segoe UI", 12F);
            buttonEmployeeAdd.Location = new Point(520, 100);
            buttonEmployeeAdd.Name = "buttonEmployeeAdd";
            buttonEmployeeAdd.Size = new Size(450, 60);
            buttonEmployeeAdd.TabIndex = 4;
            buttonEmployeeAdd.Text = "Добавить сотрудника";

            textBoxEmployeeName.Location = new Point(650, 347);
            textBoxEmployeeName.Name = "textBoxEmployeeName";
            textBoxEmployeeName.Size = new Size(320, 23);
            textBoxEmployeeName.TabIndex = 2;

            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Location = new Point(0, 0);
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.Size = new Size(500, 400);
            dataGridViewEmployees.TabIndex = 1;

            // tabPageLoans - Выдача книг
            tabPageLoans.Controls.Add(label5);
            tabPageLoans.Controls.Add(buttonLoanReturn);
            tabPageLoans.Controls.Add(buttonLoanIssue);
            tabPageLoans.Controls.Add(comboBoxLoanBook);
            tabPageLoans.Controls.Add(comboBoxLoanReader);
            tabPageLoans.Controls.Add(comboBoxLoanEmployee);
            tabPageLoans.Controls.Add(dataGridViewLoans);
            tabPageLoans.Location = new Point(4, 24);
            tabPageLoans.Name = "tabPageLoans";
            tabPageLoans.Size = new Size(992, 572);
            tabPageLoans.TabIndex = 3;
            tabPageLoans.Text = "Выдача книг";
            tabPageLoans.UseVisualStyleBackColor = true;

            label5.AutoSize = true;
            label5.Location = new Point(550, 250);
            label5.Name = "label5";
            label5.Size = new Size(248, 15);
            label5.TabIndex = 6;
            label5.Text = "Для выдачи заполните поля и нажмите кнопку";

            buttonLoanReturn.Location = new Point(550, 350);
            buttonLoanReturn.Name = "buttonLoanReturn";
            buttonLoanReturn.Size = new Size(420, 50);
            buttonLoanReturn.TabIndex = 5;
            buttonLoanReturn.Text = "Вернуть книгу (выберите запись)";

            buttonLoanIssue.Location = new Point(550, 290);
            buttonLoanIssue.Name = "buttonLoanIssue";
            buttonLoanIssue.Size = new Size(420, 50);
            buttonLoanIssue.TabIndex = 4;
            buttonLoanIssue.Text = "Выдать книгу";

            comboBoxLoanBook.Location = new Point(550, 180);
            comboBoxLoanBook.Name = "comboBoxLoanBook";
            comboBoxLoanBook.Size = new Size(420, 23);
            comboBoxLoanBook.TabIndex = 3;
            comboBoxLoanBook.Text = "Выберите книгу";

            comboBoxLoanReader.Location = new Point(550, 150);
            comboBoxLoanReader.Name = "comboBoxLoanReader";
            comboBoxLoanReader.Size = new Size(420, 23);
            comboBoxLoanReader.TabIndex = 2;
            comboBoxLoanReader.Text = "Выберите читателя";

            comboBoxLoanEmployee.Location = new Point(550, 120);
            comboBoxLoanEmployee.Name = "comboBoxLoanEmployee";
            comboBoxLoanEmployee.Size = new Size(420, 23);
            comboBoxLoanEmployee.TabIndex = 1;
            comboBoxLoanEmployee.Text = "Выберите сотрудника";

            dataGridViewLoans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLoans.Location = new Point(0, 0);
            dataGridViewLoans.Name = "dataGridViewLoans";
            dataGridViewLoans.Size = new Size(530, 550);
            dataGridViewLoans.TabIndex = 0;

            // tabPageOperations - Внутренние операции
            tabPageOperations.Controls.Add(label6);
            tabPageOperations.Controls.Add(buttonOperationAdd);
            tabPageOperations.Controls.Add(comboBoxOperationType);
            tabPageOperations.Controls.Add(comboBoxOperationBook);
            tabPageOperations.Controls.Add(comboBoxOperationEmployee);
            tabPageOperations.Controls.Add(dataGridViewOperations);
            tabPageOperations.Location = new Point(4, 24);
            tabPageOperations.Name = "tabPageOperations";
            tabPageOperations.Size = new Size(992, 572);
            tabPageOperations.TabIndex = 4;
            tabPageOperations.Text = "Внутренние операции";
            tabPageOperations.UseVisualStyleBackColor = true;

            label6.AutoSize = true;
            label6.Location = new Point(550, 180);
            label6.Name = "label6";
            label6.Size = new Size(274, 15);
            label6.TabIndex = 5;
            label6.Text = "Заполните поля и нажмите кнопку для добавления";

            buttonOperationAdd.Location = new Point(550, 220);
            buttonOperationAdd.Name = "buttonOperationAdd";
            buttonOperationAdd.Size = new Size(420, 50);
            buttonOperationAdd.TabIndex = 4;
            buttonOperationAdd.Text = "Добавить операцию";

            comboBoxOperationType.Location = new Point(550, 150);
            comboBoxOperationType.Name = "comboBoxOperationType";
            comboBoxOperationType.Size = new Size(420, 23);
            comboBoxOperationType.TabIndex = 3;
            comboBoxOperationType.Items.AddRange(new string[] { "Списание", "Ремонт", "Инвентаризация", "Перемещение" });

            comboBoxOperationBook.Location = new Point(550, 120);
            comboBoxOperationBook.Name = "comboBoxOperationBook";
            comboBoxOperationBook.Size = new Size(420, 23);
            comboBoxOperationBook.TabIndex = 2;
            comboBoxOperationBook.Text = "Выберите книгу";

            comboBoxOperationEmployee.Location = new Point(550, 90);
            comboBoxOperationEmployee.Name = "comboBoxOperationEmployee";
            comboBoxOperationEmployee.Size = new Size(420, 23);
            comboBoxOperationEmployee.TabIndex = 1;
            comboBoxOperationEmployee.Text = "Выберите сотрудника";

            dataGridViewOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOperations.Location = new Point(0, 0);
            dataGridViewOperations.Name = "dataGridViewOperations";
            dataGridViewOperations.Size = new Size(530, 550);
            dataGridViewOperations.TabIndex = 0;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 620);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Библиотечная система";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageBooks.ResumeLayout(false);
            tabPageBooks.PerformLayout();
            tabPageReaders.ResumeLayout(false);
            tabPageReaders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReaders).EndInit();
            tabPageEmployees.ResumeLayout(false);
            tabPageEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            tabPageLoans.ResumeLayout(false);
            tabPageLoans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLoans).EndInit();
            tabPageOperations.ResumeLayout(false);
            tabPageOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewBooks;
        private TabControl tabControl1;
        private TabPage tabPageBooks;
        private TabPage tabPageReaders;
        private TabPage tabPageEmployees;
        private TabPage tabPageLoans;
        private TabPage tabPageOperations;

        private DataGridView dataGridViewReaders;
        private DataGridView dataGridViewEmployees;
        private DataGridView dataGridViewLoans;
        private DataGridView dataGridViewOperations;

        private Button buttonBookAdd;
        private Button buttonBookUpdate;
        private Button buttonBookDelete;
        private TextBox textBoxBookName;
        private ComboBox comboBoxGenre;
        private Label label1;
        private Label label2;

        private Button buttonReaderAdd;
        private Button buttonReaderUpdate;
        private Button buttonReaderDelete;
        private TextBox textBoxReaderName;
        private TextBox textBoxReaderInfo;
        private Label label3;

        private Button buttonEmployeeAdd;
        private Button buttonEmployeeUpdate;
        private Button buttonEmployeeDelete;
        private TextBox textBoxEmployeeName;
        private TextBox textBoxEmployeeAge;
        private Label label4;

        private Button buttonLoanIssue;
        private Button buttonLoanReturn;
        private ComboBox comboBoxLoanBook;
        private ComboBox comboBoxLoanReader;
        private ComboBox comboBoxLoanEmployee;
        private Label label5;

        private Button buttonOperationAdd;
        private ComboBox comboBoxOperationType;
        private ComboBox comboBoxOperationBook;
        private ComboBox comboBoxOperationEmployee;
        private Label label6;
    }
}