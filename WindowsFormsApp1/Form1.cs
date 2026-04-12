using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=library1.mdb;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        // ================= БАЗА =================
        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                new OleDbDataAdapter(query, conn).Fill(dt);
            }
            return dt;
        }

        private void ExecuteNonQuery(string query)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                new OleDbCommand(query, conn).ExecuteNonQuery();
            }
        }

        private void LoadAll()
        {
            LoadBooks();
            LoadReaders();
            LoadEmployees();
            LoadLoans();
            LoadOperations();
            LoadCombos();
        }

        // ================= КНИГИ =================
        private void LoadBooks()
        {
            dataGridViewBooks.DataSource =
                ExecuteQuery("SELECT [ID Книги], Название, [ФИО автора], [Дата написания], Жанр, Стоимость FROM Книги");
        }

        private void buttonBookAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookName.Text)) return;

            decimal price = 0;
            decimal.TryParse(textBoxPrice.Text, out price);

            DateTime date = dateTimePickerBook.Value;

            ExecuteNonQuery($@"
            INSERT INTO Книги (Название, [ФИО автора], [Дата написания], Жанр, Стоимость)
            VALUES ('{textBoxBookName.Text}',
                    '{textBoxAuthor.Text}',
                    #{date:yyyy-MM-dd}#,
                    '{textBoxGenre.Text}',
                    {price})");

            LoadBooks();
        }

        private void buttonBookUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells[0].Value);

            decimal price = 0;
            decimal.TryParse(textBoxPrice.Text, out price);

            DateTime date = dateTimePickerBook.Value;

            ExecuteNonQuery($@"
            UPDATE Книги SET 
                Название='{textBoxBookName.Text}',
                [ФИО автора]='{textBoxAuthor.Text}',
                [Дата написания]=#{date:yyyy-MM-dd}#,
                Жанр='{textBoxGenre.Text}',
                Стоимость={price}
            WHERE [ID Книги]={id}");

            LoadBooks();
        }

        private void buttonBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($"DELETE FROM Книги WHERE [ID Книги]={id}");
            LoadBooks();
        }

        // ================= ЧИТАТЕЛИ =================
        private void LoadReaders()
        {
            dataGridViewReaders.DataSource =
                ExecuteQuery("SELECT [ID Читателя], ФИО, [Номер телефона] FROM Читатель");
        }

        private void buttonReaderAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxReader.Text)) return;

            ExecuteNonQuery($@"
            INSERT INTO Читатель (ФИО, [Номер телефона])
            VALUES ('{textBoxReader.Text}', '{textBoxPhone.Text}')");

            LoadReaders();
        }

        private void buttonReaderUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($@"
            UPDATE Читатель SET 
                ФИО='{textBoxReader.Text}', 
                [Номер телефона]='{textBoxPhone.Text}'
            WHERE [ID Читателя]={id}");

            LoadReaders();
        }

        private void buttonReaderDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($"DELETE FROM Читатель WHERE [ID Читателя]={id}");
            LoadReaders();
        }

        // ================= СОТРУДНИКИ =================
        private void LoadEmployees()
        {
            dataGridViewEmployees.DataSource =
                ExecuteQuery("SELECT [ID Сотрудника], ФИО, Должность FROM Сотрудник");
        }

        private void buttonEmployeeAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmployee.Text)) return;

            ExecuteNonQuery($@"
            INSERT INTO Сотрудник (ФИО, Должность)
            VALUES ('{textBoxEmployee.Text}', '{textBoxPosition.Text}')");

            LoadEmployees();
        }

        private void buttonEmployeeUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($@"
            UPDATE Сотрудник SET 
                ФИО='{textBoxEmployee.Text}', 
                Должность='{textBoxPosition.Text}'
            WHERE [ID Сотрудника]={id}");

            LoadEmployees();
        }

        private void buttonEmployeeDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($"DELETE FROM Сотрудник WHERE [ID Сотрудника]={id}");
            LoadEmployees();
        }

        // ================= ВЫДАЧА (JOIN) =================
        private void LoadLoans()
        {
            dataGridViewLoans.DataSource =
                ExecuteQuery(@"
                SELECT Выдача.[ID Операции],
                       Книги.Название AS Книга,
                       Читатель.ФИО AS Читатель,
                       Сотрудник.ФИО AS Сотрудник,
                       Выдача.[Дата выдачи],
                       Выдача.[Дата возврата],
                       Выдача.[Тип Операции]
                FROM ((Выдача
                INNER JOIN Книги ON Выдача.[ID Книги]=Книги.[ID Книги])
                INNER JOIN Читатель ON Выдача.Клиент=Читатель.[ID Читателя])
                INNER JOIN Сотрудник ON Выдача.Оператор=Сотрудник.[ID Сотрудника]");
        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            if (comboBoxBook.SelectedValue == null ||
                comboBoxReader.SelectedValue == null ||
                comboBoxEmployee.SelectedValue == null)
                return;

            ExecuteNonQuery($@"
            INSERT INTO Выдача ([Тип Операции], Оператор, Клиент, [Дата выдачи], [Дата возврата], [ID Книги])
            VALUES ('Выдача',
                    {comboBoxEmployee.SelectedValue},
                    {comboBoxReader.SelectedValue},
                    #{DateTime.Now:yyyy-MM-dd}#,
                    #{DateTime.Now.AddDays(14):yyyy-MM-dd}#,
                    {comboBoxBook.SelectedValue})");

            LoadLoans();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoans.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridViewLoans.CurrentRow.Cells[0].Value);

            ExecuteNonQuery($@"
            UPDATE Выдача 
            SET [Тип Операции]='Возврат',
                [Фактическая Дата Возврата]=#{DateTime.Now:yyyy-MM-dd}#
            WHERE [ID Операции]={id}");

            LoadLoans();
        }

        // ================= ОПЕРАЦИИ (JOIN) =================
        private void LoadOperations()
        {
            dataGridViewOperations.DataSource =
                ExecuteQuery(@"
                SELECT [Внутренние Операции].[ID Операции],
                       [Тип операции],
                       Сотрудник.ФИО,
                       Книги.Название,
                       Дата
                FROM ([Внутренние Операции]
                INNER JOIN Сотрудник ON Сотрудник.[ID Сотрудника]=[Внутренние Операции].Сотрудник)
                INNER JOIN Книги ON Книги.[ID Книги]=[Внутренние Операции].[ID Книги]");
        }

        private void buttonOperationAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxBookOp.SelectedValue == null ||
                comboBoxEmployeeOp.SelectedValue == null)
                return;

            ExecuteNonQuery($@"
            INSERT INTO [Внутренние Операции] ([Тип операции], Сотрудник, Дата, [ID Книги])
            VALUES ('{comboBoxOperationType.Text}',
                    {comboBoxEmployeeOp.SelectedValue},
                    #{DateTime.Now:yyyy-MM-dd}#,
                    {comboBoxBookOp.SelectedValue})");

            LoadOperations();
        }

        // ================= COMBO =================
        private void LoadCombos()
        {
            comboBoxBook.DataSource = ExecuteQuery("SELECT [ID Книги], Название FROM Книги");
            comboBoxBook.DisplayMember = "Название";
            comboBoxBook.ValueMember = "ID Книги";

            comboBoxReader.DataSource = ExecuteQuery("SELECT [ID Читателя], ФИО FROM Читатель");
            comboBoxReader.DisplayMember = "ФИО";
            comboBoxReader.ValueMember = "ID Читателя";

            comboBoxEmployee.DataSource = ExecuteQuery("SELECT [ID Сотрудника], ФИО FROM Сотрудник");
            comboBoxEmployee.DisplayMember = "ФИО";
            comboBoxEmployee.ValueMember = "ID Сотрудника";

            comboBoxBookOp.DataSource = ExecuteQuery("SELECT [ID Книги], Название FROM Книги");
            comboBoxBookOp.DisplayMember = "Название";
            comboBoxBookOp.ValueMember = "ID Книги";

            comboBoxEmployeeOp.DataSource = ExecuteQuery("SELECT [ID Сотрудника], ФИО FROM Сотрудник");
            comboBoxEmployeeOp.DisplayMember = "ФИО";
            comboBoxEmployeeOp.ValueMember = "ID Сотрудника";
        }
    }
}
