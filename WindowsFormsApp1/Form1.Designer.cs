namespace LibraryApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBooks, tabReaders, tabEmployees, tabLoans, tabOperations;

        private System.Windows.Forms.DataGridView dataGridViewBooks, dataGridViewReaders, dataGridViewEmployees, dataGridViewLoans, dataGridViewOperations;

        private System.Windows.Forms.TextBox textBoxBookName, textBoxAuthor, textBoxGenre, textBoxYear, textBoxPrice;
        private System.Windows.Forms.TextBox textBoxReader, textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEmployee, textBoxPosition;

        private System.Windows.Forms.ComboBox comboBoxBook, comboBoxReader, comboBoxEmployee;
        private System.Windows.Forms.ComboBox comboBoxBookOp, comboBoxEmployeeOp, comboBoxOperationType;

        private System.Windows.Forms.Button buttonBookAdd, buttonBookUpdate, buttonBookDelete;
        private System.Windows.Forms.Button buttonReaderAdd, buttonReaderUpdate, buttonReaderDelete;
        private System.Windows.Forms.Button buttonEmployeeAdd, buttonEmployeeUpdate, buttonEmployeeDelete;
        private System.Windows.Forms.Button buttonIssue, buttonReturn;
        private System.Windows.Forms.Button buttonOperationAdd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBook;

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dateTimePickerBook = new System.Windows.Forms.DateTimePicker();

            this.tabBooks = new System.Windows.Forms.TabPage("Книги");
            this.tabReaders = new System.Windows.Forms.TabPage("Читатели");
            this.tabEmployees = new System.Windows.Forms.TabPage("Сотрудники");
            this.tabLoans = new System.Windows.Forms.TabPage("Выдача");
            this.tabOperations = new System.Windows.Forms.TabPage("Операции");

            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.dataGridViewLoans = new System.Windows.Forms.DataGridView();
            this.dataGridViewOperations = new System.Windows.Forms.DataGridView();

            this.textBoxBookName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();

            this.textBoxReader = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();

            this.textBoxEmployee = new System.Windows.Forms.TextBox();
            this.textBoxPosition = new System.Windows.Forms.TextBox();

            this.comboBoxBook = new System.Windows.Forms.ComboBox();
            this.comboBoxReader = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();

            this.comboBoxBookOp = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployeeOp = new System.Windows.Forms.ComboBox();
            this.comboBoxOperationType = new System.Windows.Forms.ComboBox();

            this.buttonBookAdd = new System.Windows.Forms.Button();
            this.buttonBookUpdate = new System.Windows.Forms.Button();
            this.buttonBookDelete = new System.Windows.Forms.Button();

            this.buttonReaderAdd = new System.Windows.Forms.Button();
            this.buttonReaderUpdate = new System.Windows.Forms.Button();
            this.buttonReaderDelete = new System.Windows.Forms.Button();

            this.buttonEmployeeAdd = new System.Windows.Forms.Button();
            this.buttonEmployeeUpdate = new System.Windows.Forms.Button();
            this.buttonEmployeeDelete = new System.Windows.Forms.Button();

            this.buttonIssue = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();

            this.buttonOperationAdd = new System.Windows.Forms.Button();

            // TABCONTROL
            tabBooks.Controls.Add(dateTimePickerBook);

            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
                tabBooks, tabReaders, tabEmployees, tabLoans, tabOperations
            });

            // ================= КНИГИ =================
            dataGridViewBooks.Dock = System.Windows.Forms.DockStyle.Top;
            dataGridViewBooks.Height = 250;

            textBoxBookName.SetBounds(10, 260, 120, 25);
            textBoxAuthor.SetBounds(140, 260, 120, 25);
            textBoxGenre.SetBounds(270, 260, 100, 25);
            textBoxYear.SetBounds(380, 260, 80, 25);
            textBoxPrice.SetBounds(470, 260, 80, 25);
            dateTimePickerBook.SetBounds(380, 260, 120, 25);
            dateTimePickerBook.Format = System.Windows.Forms.DateTimePickerFormat.Short;


            buttonBookAdd.Text = "Добавить";
            buttonBookAdd.SetBounds(10, 300, 100, 30);
            buttonBookAdd.Click += buttonBookAdd_Click;

            buttonBookUpdate.Text = "Изменить";
            buttonBookUpdate.SetBounds(120, 300, 100, 30);
            buttonBookUpdate.Click += buttonBookUpdate_Click;

            buttonBookDelete.Text = "Удалить";
            buttonBookDelete.SetBounds(230, 300, 100, 30);
            buttonBookDelete.Click += buttonBookDelete_Click;

            tabBooks.Controls.AddRange(new System.Windows.Forms.Control[] {
                dataGridViewBooks, textBoxBookName, textBoxAuthor,
                textBoxGenre, textBoxYear, textBoxPrice,
                buttonBookAdd, buttonBookUpdate, buttonBookDelete
            });

            // ================= ЧИТАТЕЛИ =================
            dataGridViewReaders.Dock = System.Windows.Forms.DockStyle.Top;
            dataGridViewReaders.Height = 250;

            textBoxReader.SetBounds(10, 260, 150, 25);
            textBoxPhone.SetBounds(170, 260, 150, 25);

            buttonReaderAdd.Text = "Добавить";
            buttonReaderAdd.SetBounds(10, 300, 100, 30);
            buttonReaderAdd.Click += buttonReaderAdd_Click;

            buttonReaderUpdate.Text = "Изменить";
            buttonReaderUpdate.SetBounds(120, 300, 100, 30);
            buttonReaderUpdate.Click += buttonReaderUpdate_Click;

            buttonReaderDelete.Text = "Удалить";
            buttonReaderDelete.SetBounds(230, 300, 100, 30);
            buttonReaderDelete.Click += buttonReaderDelete_Click;

            tabReaders.Controls.AddRange(new System.Windows.Forms.Control[] {
                dataGridViewReaders, textBoxReader, textBoxPhone,
                buttonReaderAdd, buttonReaderUpdate, buttonReaderDelete
            });

            // ================= СОТРУДНИКИ =================
            dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            dataGridViewEmployees.Height = 250;

            textBoxEmployee.SetBounds(10, 260, 150, 25);
            textBoxPosition.SetBounds(170, 260, 150, 25);

            buttonEmployeeAdd.Text = "Добавить";
            buttonEmployeeAdd.SetBounds(10, 300, 100, 30);
            buttonEmployeeAdd.Click += buttonEmployeeAdd_Click;

            buttonEmployeeUpdate.Text = "Изменить";
            buttonEmployeeUpdate.SetBounds(120, 300, 100, 30);
            buttonEmployeeUpdate.Click += buttonEmployeeUpdate_Click;

            buttonEmployeeDelete.Text = "Удалить";
            buttonEmployeeDelete.SetBounds(230, 300, 100, 30);
            buttonEmployeeDelete.Click += buttonEmployeeDelete_Click;

            tabEmployees.Controls.AddRange(new System.Windows.Forms.Control[] {
                dataGridViewEmployees, textBoxEmployee, textBoxPosition,
                buttonEmployeeAdd, buttonEmployeeUpdate, buttonEmployeeDelete
            });

            // ================= ВЫДАЧА =================
            dataGridViewLoans.Dock = System.Windows.Forms.DockStyle.Top;
            dataGridViewLoans.Height = 250;

            comboBoxBook.SetBounds(10, 260, 150, 25);
            comboBoxReader.SetBounds(170, 260, 150, 25);
            comboBoxEmployee.SetBounds(330, 260, 150, 25);

            buttonIssue.Text = "Выдать";
            buttonIssue.SetBounds(10, 300, 100, 30);
            buttonIssue.Click += buttonIssue_Click;

            buttonReturn.Text = "Вернуть";
            buttonReturn.SetBounds(120, 300, 100, 30);
            buttonReturn.Click += buttonReturn_Click;

            tabLoans.Controls.AddRange(new System.Windows.Forms.Control[] {
                dataGridViewLoans, comboBoxBook, comboBoxReader, comboBoxEmployee,
                buttonIssue, buttonReturn
            });

            // ================= ОПЕРАЦИИ =================
            dataGridViewOperations.Dock = System.Windows.Forms.DockStyle.Top;
            dataGridViewOperations.Height = 250;

            comboBoxBookOp.SetBounds(10, 260, 150, 25);
            comboBoxEmployeeOp.SetBounds(170, 260, 150, 25);
            comboBoxOperationType.SetBounds(330, 260, 150, 25);

            comboBoxOperationType.Items.AddRange(new object[] {
                "Списание", "Ремонт", "Инвентаризация"
            });

            buttonOperationAdd.Text = "Добавить";
            buttonOperationAdd.SetBounds(10, 300, 120, 30);
            buttonOperationAdd.Click += buttonOperationAdd_Click;

            tabOperations.Controls.AddRange(new System.Windows.Forms.Control[] {
                dataGridViewOperations, comboBoxBookOp, comboBoxEmployeeOp,
                comboBoxOperationType, buttonOperationAdd
            });

            // FORM
            this.Controls.Add(tabControl1);
            this.Text = "Библиотека";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
        }
    }
}
