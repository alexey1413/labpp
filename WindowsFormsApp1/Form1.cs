using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=library1.mdb;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadReaders();
            LoadEmployees();
            LoadLoans();
            LoadOperations();
            LoadComboBoxes();
            LoadGenres();
            HideColumns();
        }

        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        private void ExecuteNonQuery(string query)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==================== КНИГИ ====================
        private void LoadBooks()
        {
            string query = "SELECT [ID Книги], Название, [ФИО автора], [Дата написания], Жанр, Стоимость FROM Книги";
            dataGridViewBooks.DataSource = ExecuteQuery(query);
        }

        private void buttonBookAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookName.Text))
            {
                MessageBox.Show("Введите название книги!");
                return;
            }

            try
            {
                string nazvanie = textBoxBookName.Text;
                string author = "Неизвестен";
                string genre = comboBoxGenre.Text;
                int year = DateTime.Now.Year;
                decimal price = 0;

                string query = $@"INSERT INTO Книги (Название, [ФИО автора], [Дата написания], Жанр, Стоимость) 
                               VALUES ('{nazvanie}', '{author}', {year}, '{genre}', {price})";

                ExecuteNonQuery(query);
                LoadBooks();
                LoadGenres();
                textBoxBookName.Clear();
                MessageBox.Show("Книга добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonBookUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID Книги"].Value);
                string nazvanie = textBoxBookName.Text;
                string genre = comboBoxGenre.Text;

                string query = $@"UPDATE Книги SET Название = '{nazvanie}', Жанр = '{genre}' 
                               WHERE [ID Книги] = {id}";

                ExecuteNonQuery(query);
                LoadBooks();
                textBoxBookName.Clear();
                MessageBox.Show("Книга изменена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            if (MessageBox.Show("Удалить книгу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID Книги"].Value);
                    string query = $"DELETE FROM Книги WHERE [ID Книги] = {id}";
                    ExecuteNonQuery(query);
                    LoadBooks();
                    LoadGenres();
                    MessageBox.Show("Книга удалена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== ЧИТАТЕЛИ ====================
        private void LoadReaders()
        {
            string query = "SELECT [ID Читателя], ФИО, [Номер телефона] FROM Читатель";
            dataGridViewReaders.DataSource = ExecuteQuery(query);
        }

        private void buttonReaderAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxReaderName.Text))
            {
                MessageBox.Show("Введите ФИО читателя!");
                return;
            }

            try
            {
                string fio = textBoxReaderName.Text;
                string phone = textBoxReaderInfo.Text;

                string query = $"INSERT INTO Читатель (ФИО, [Номер телефона]) VALUES ('{fio}', '{phone}')";
                ExecuteNonQuery(query);
                LoadReaders();
                textBoxReaderName.Clear();
                textBoxReaderInfo.Clear();
                MessageBox.Show("Читатель добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonReaderUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID Читателя"].Value);
                string fio = textBoxReaderName.Text;
                string phone = textBoxReaderInfo.Text;

                string query = $"UPDATE Читатель SET ФИО = '{fio}', [Номер телефона] = '{phone}' WHERE [ID Читателя] = {id}";
                ExecuteNonQuery(query);
                LoadReaders();
                textBoxReaderName.Clear();
                textBoxReaderInfo.Clear();
                MessageBox.Show("Читатель изменен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonReaderDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }

            if (MessageBox.Show("Удалить читателя?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID Читателя"].Value);
                    string query = $"DELETE FROM Читатель WHERE [ID Читателя] = {id}";
                    ExecuteNonQuery(query);
                    LoadReaders();
                    MessageBox.Show("Читатель удален!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== СОТРУДНИКИ ====================
        private void LoadEmployees()
        {
            string query = "SELECT [ID Сотрудника], ФИО, Должность FROM Сотрудник";
            dataGridViewEmployees.DataSource = ExecuteQuery(query);
        }

        private void buttonEmployeeAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmployeeName.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника!");
                return;
            }

            try
            {
                string fio = textBoxEmployeeName.Text;
                string dolgnost = textBoxEmployeeAge.Text;

                string query = $"INSERT INTO Сотрудник (ФИО, Должность) VALUES ('{fio}', '{dolgnost}')";
                ExecuteNonQuery(query);
                LoadEmployees();
                textBoxEmployeeName.Clear();
                textBoxEmployeeAge.Clear();
                MessageBox.Show("Сотрудник добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonEmployeeUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID Сотрудника"].Value);
                string fio = textBoxEmployeeName.Text;
                string dolgnost = textBoxEmployeeAge.Text;

                string query = $"UPDATE Сотрудник SET ФИО = '{fio}', Должность = '{dolgnost}' WHERE [ID Сотрудника] = {id}";
                ExecuteNonQuery(query);
                LoadEmployees();
                textBoxEmployeeName.Clear();
                textBoxEmployeeAge.Clear();
                MessageBox.Show("Сотрудник изменен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonEmployeeDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID Сотрудника"].Value);
                    string query = $"DELETE FROM Сотрудник WHERE [ID Сотрудника] = {id}";
                    ExecuteNonQuery(query);
                    LoadEmployees();
                    MessageBox.Show("Сотрудник удален!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== ВЫДАЧА КНИГ ====================
        private void LoadLoans()
        {
            string query = @"SELECT Выдача.[ID Операции], 
                                    Книги.Название AS Книга, 
                                    Читатель.ФИО AS Читатель, 
                                    Сотрудник.ФИО AS Оператор, 
                                    Выдача.[Дата выдачи], 
                                    Выдача.[Дата возврата], 
                                    Выдача.[Фактическая Дата Возврата], 
                                    Выдача.[Тип Операции]
                             FROM ((Выдача 
                             INNER JOIN Книги ON Выдача.[ID Книги] = Книги.[ID Книги])
                             INNER JOIN Читатель ON Выдача.Клиент = Читатель.[ID Читателя])
                             INNER JOIN Сотрудник ON Выдача.Оператор = Сотрудник.[ID Сотрудника]
                             ORDER BY Выдача.[ID Операции] DESC";
            dataGridViewLoans.DataSource = ExecuteQuery(query);
        }

        private void buttonLoanIssue_Click(object sender, EventArgs e)
        {
            if (comboBoxLoanBook.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }
            if (comboBoxLoanReader.SelectedValue == null)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }
            if (comboBoxLoanEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            try
            {
                int bookId = Convert.ToInt32(comboBoxLoanBook.SelectedValue);
                int readerId = Convert.ToInt32(comboBoxLoanReader.SelectedValue);
                int employeeId = Convert.ToInt32(comboBoxLoanEmployee.SelectedValue);
                DateTime dateOut = DateTime.Now;
                DateTime dateReturn = DateTime.Now.AddDays(14);

                string query = $@"INSERT INTO Выдача ([Тип Операции], Оператор, Клиент, [Дата выдачи], [Дата возврата], [ID Книги]) 
                               VALUES ('Выдача', {employeeId}, {readerId}, #{dateOut:yyyy-MM-dd}#, #{dateReturn:yyyy-MM-dd}#, {bookId})";

                ExecuteNonQuery(query);
                LoadLoans();
                MessageBox.Show($"Книга выдана! Дата возврата: {dateReturn:dd.MM.yyyy}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonLoanReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoans.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись о выдаче!");
                return;
            }

            int id = Convert.ToInt32(dataGridViewLoans.CurrentRow.Cells["ID Операции"].Value);
            string bookName = dataGridViewLoans.CurrentRow.Cells["Книга"].Value.ToString();

            if (MessageBox.Show($"Вернуть книгу '{bookName}'?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DateTime dateNow = DateTime.Now;
                    string query = $@"UPDATE Выдача SET [Тип Операции] = 'Возврат', [Фактическая Дата Возврата] = #{dateNow:yyyy-MM-dd}# 
                                   WHERE [ID Операции] = {id}";

                    ExecuteNonQuery(query);
                    LoadLoans();
                    MessageBox.Show("Книга возвращена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== ВНУТРЕННИЕ ОПЕРАЦИИ ====================
        private void LoadOperations()
        {
            string query = @"SELECT [Внутренние Операции].[ID Операции], 
                                    [Внутренние Операции].[Тип операции], 
                                    Сотрудник.ФИО AS Сотрудник, 
                                    [Внутренние Операции].Дата, 
                                    Книги.Название AS Книга
                             FROM ([Внутренние Операции] 
                             INNER JOIN Сотрудник ON [Внутренние Операции].Сотрудник = Сотрудник.[ID Сотрудника])
                             INNER JOIN Книги ON [Внутренние Операции].[ID Книги] = Книги.[ID Книги]
                             ORDER BY [Внутренние Операции].[ID Операции] DESC";
            dataGridViewOperations.DataSource = ExecuteQuery(query);
        }

        private void buttonOperationAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxOperationBook.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }
            if (comboBoxOperationEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxOperationType.Text))
            {
                MessageBox.Show("Выберите тип операции!");
                return;
            }

            try
            {
                int bookId = Convert.ToInt32(comboBoxOperationBook.SelectedValue);
                int employeeId = Convert.ToInt32(comboBoxOperationEmployee.SelectedValue);
                string type = comboBoxOperationType.Text;
                DateTime date = DateTime.Now;

                string query = $@"INSERT INTO [Внутренние Операции] ([Тип операции], Сотрудник, Дата, [ID Книги]) 
                               VALUES ('{type}', {employeeId}, #{date:yyyy-MM-dd}#, {bookId})";

                ExecuteNonQuery(query);
                LoadOperations();
                MessageBox.Show("Операция добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ====================
        private void LoadComboBoxes()
        {
            LoadCombo("SELECT [ID Книги], Название FROM Книги", "Название", "ID Книги", comboBoxLoanBook);
            LoadCombo("SELECT [ID Книги], Название FROM Книги", "Название", "ID Книги", comboBoxOperationBook);
            LoadCombo("SELECT [ID Читателя], ФИО FROM Читатель", "ФИО", "ID Читателя", comboBoxLoanReader);
            LoadCombo("SELECT [ID Сотрудника], ФИО FROM Сотрудник", "ФИО", "ID Сотрудника", comboBoxLoanEmployee);
            LoadCombo("SELECT [ID Сотрудника], ФИО FROM Сотрудник", "ФИО", "ID Сотрудника", comboBoxOperationEmployee);
        }

        private void LoadCombo(string query, string display, string value, ComboBox box)
        {
            try
            {
                DataTable dt = ExecuteQuery(query);
                box.DataSource = dt;
                box.DisplayMember = display;
                box.ValueMember = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка: " + ex.Message);
            }
        }

        private void LoadGenres()
        {
            try
            {
                string query = "SELECT DISTINCT Жанр FROM Книги WHERE Жанр IS NOT NULL AND Жанр <> ''";
                DataTable dt = ExecuteQuery(query);
                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.Add("");
                foreach (DataRow row in dt.Rows)
                {
                    comboBoxGenre.Items.Add(row["Жанр"].ToString());
                }

                if (comboBoxGenre.Items.Count <= 1)
                {
                    comboBoxGenre.Items.Add("Роман");
                    comboBoxGenre.Items.Add("Детектив");
                    comboBoxGenre.Items.Add("Фантастика");
                    comboBoxGenre.Items.Add("Поэзия");
                    comboBoxGenre.Items.Add("Наука");
                }
            }
            catch (Exception ex)
            {
                comboBoxGenre.Items.Clear();
                comboBoxGenre.Items.Add("");
                comboBoxGenre.Items.Add("Роман");
                comboBoxGenre.Items.Add("Детектив");
                comboBoxGenre.Items.Add("Фантастика");
                comboBoxGenre.Items.Add("Поэзия");
                comboBoxGenre.Items.Add("Наука");
            }
        }

        private void HideColumns()
        {
            HideColumn(dataGridViewBooks, "ID Книги");
            HideColumn(dataGridViewReaders, "ID Читателя");
            HideColumn(dataGridViewEmployees, "ID Сотрудника");
            HideColumn(dataGridViewLoans, "ID Операции");
            HideColumn(dataGridViewOperations, "ID Операции");
        }

        private void HideColumn(DataGridView grid, string columnName)
        {
            if (grid.Columns[columnName] != null)
                grid.Columns[columnName].Visible = false;
        }
    }
}