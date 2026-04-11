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

        // ========== КНИГИ ==========
        private void LoadBooks()
        {
            string query = "SELECT * FROM Книги";
            dataGridViewBooks.DataSource = ExecuteQuery(query);
        }

        // ========== ЧИТАТЕЛИ ==========
        private void LoadReaders()
        {
            string query = "SELECT * FROM Читатель";
            dataGridViewReaders.DataSource = ExecuteQuery(query);
        }

        // ========== СОТРУДНИКИ ==========
        private void LoadEmployees()
        {
            string query = "SELECT * FROM Сотрудник";
            dataGridViewEmployees.DataSource = ExecuteQuery(query);
        }

        // ========== ВЫДАЧА КНИГ ==========
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

        // ========== ВНУТРЕННИЕ ОПЕРАЦИИ ==========
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

        private void LoadComboBoxes()
        {
            LoadCombo("SELECT [ID Книги], Название FROM Книги", "Название", "ID Книги", comboBoxLoanBook);
            LoadCombo("SELECT [ID Читателя], ФИО FROM Читатель", "ФИО", "ID Читателя", comboBoxLoanReader);
            LoadCombo("SELECT [ID Сотрудника], ФИО FROM Сотрудник", "ФИО", "ID Сотрудника", comboBoxLoanEmployee);
            LoadCombo("SELECT [ID Книги], Название FROM Книги", "Название", "ID Книги", comboBoxOperationBook);
            LoadCombo("SELECT [ID Сотрудника], ФИО FROM Сотрудник", "ФИО", "ID Сотрудника", comboBoxOperationEmployee);
        }

        private void LoadCombo(string query, string display, string value, ComboBox box)
        {
            DataTable dt = ExecuteQuery(query);
            box.DataSource = dt;
            box.DisplayMember = display;
            box.ValueMember = value;
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
            }
            catch (Exception ex)
            {
                comboBoxGenre.Items.Add("");
            }
        }

        private void HideColumns()
        {
            if (dataGridViewBooks.Columns["ID Книги"] != null)
                dataGridViewBooks.Columns["ID Книги"].Visible = false;
            if (dataGridViewReaders.Columns["ID Читателя"] != null)
                dataGridViewReaders.Columns["ID Читателя"].Visible = false;
            if (dataGridViewEmployees.Columns["ID Сотрудника"] != null)
                dataGridViewEmployees.Columns["ID Сотрудника"].Visible = false;
            if (dataGridViewLoans.Columns["ID Операции"] != null)
                dataGridViewLoans.Columns["ID Операции"].Visible = false;
            if (dataGridViewOperations.Columns["ID Операции"] != null)
                dataGridViewOperations.Columns["ID Операции"].Visible = false;
        }

        // ========== КНИГИ (ПОЛНЫЙ CRUD) ==========
        private void buttonBookAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookName.Text))
            {
                MessageBox.Show("Введите название книги!");
                return;
            }

            // Получаем данные из полей (если они есть на форме)
            string author = "Не указан";
            string genre = comboBoxGenre.Text;
            decimal price = 0;
            DateTime date = DateTime.Now;

            // Если есть дополнительные поля для ввода, добавьте их
            // Например: author = textBoxAuthor.Text;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Книги (Название, [ФИО автора], [Дата написания], Жанр, Стоимость) 
                                   VALUES (@Название, @Автор, @Дата, @Жанр, @Стоимость)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Название", textBoxBookName.Text);
                    cmd.Parameters.AddWithValue("@Автор", author);
                    cmd.Parameters.AddWithValue("@Дата", date);
                    cmd.Parameters.AddWithValue("@Жанр", genre);
                    cmd.Parameters.AddWithValue("@Стоимость", price);
                    cmd.ExecuteNonQuery();
                }
                LoadBooks();
                textBoxBookName.Clear();
                LoadGenres();
                MessageBox.Show("Книга добавлена!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonBookUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }
            int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID Книги"].Value);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Книги SET Название = @Название, Жанр = @Жанр WHERE [ID Книги] = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Название", textBoxBookName.Text);
                    cmd.Parameters.AddWithValue("@Жанр", comboBoxGenre.Text);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadBooks();
                textBoxBookName.Clear();
                MessageBox.Show("Книга изменена!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
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
                int id = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID Книги"].Value);
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Книги WHERE [ID Книги] = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadBooks();
                    LoadGenres();
                    MessageBox.Show("Книга удалена!");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ========== ЧИТАТЕЛИ (ПОЛНЫЙ CRUD) ==========
        private void buttonReaderAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxReaderName.Text))
            {
                MessageBox.Show("Введите ФИО читателя!");
                return;
            }

            string phone = textBoxReaderInfo.Text; // Номер телефона

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Читатель (ФИО, [Номер телефона]) VALUES (@ФИО, @Телефон)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxReaderName.Text);
                    cmd.Parameters.AddWithValue("@Телефон", phone);
                    cmd.ExecuteNonQuery();
                }
                LoadReaders();
                textBoxReaderName.Clear();
                textBoxReaderInfo.Clear();
                MessageBox.Show("Читатель добавлен!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonReaderUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null)
            {
                MessageBox.Show("Выберите читателя!");
                return;
            }
            int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID Читателя"].Value);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Читатель SET ФИО = @ФИО, [Номер телефона] = @Телефон WHERE [ID Читателя] = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxReaderName.Text);
                    cmd.Parameters.AddWithValue("@Телефон", textBoxReaderInfo.Text);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadReaders();
                textBoxReaderName.Clear();
                textBoxReaderInfo.Clear();
                MessageBox.Show("Читатель изменен!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
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
                int id = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID Читателя"].Value);
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Читатель WHERE [ID Читателя] = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadReaders();
                    MessageBox.Show("Читатель удален!");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ========== СОТРУДНИКИ (ПОЛНЫЙ CRUD) ==========
        private void buttonEmployeeAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmployeeName.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника!");
                return;
            }

            string position = textBoxEmployeeAge.Text; // Должность

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Сотрудник (ФИО, Должность) VALUES (@ФИО, @Должность)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@Должность", position);
                    cmd.ExecuteNonQuery();
                }
                LoadEmployees();
                textBoxEmployeeName.Clear();
                textBoxEmployeeAge.Clear();
                MessageBox.Show("Сотрудник добавлен!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonEmployeeUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }
            int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID Сотрудника"].Value);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Сотрудник SET ФИО = @ФИО, Должность = @Должность WHERE [ID Сотрудника] = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@Должность", textBoxEmployeeAge.Text);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadEmployees();
                textBoxEmployeeName.Clear();
                textBoxEmployeeAge.Clear();
                MessageBox.Show("Сотрудник изменен!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
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
                int id = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID Сотрудника"].Value);
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Сотрудник WHERE [ID Сотрудника] = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadEmployees();
                    MessageBox.Show("Сотрудник удален!");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ========== ВЫДАЧА КНИГ ==========
        private void buttonLoanIssue_Click(object sender, EventArgs e)
        {
            if (comboBoxLoanBook.SelectedValue == null || comboBoxLoanReader.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу и читателя!");
                return;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Выдача ([Тип Операции], Оператор, Клиент, [Дата выдачи], [Дата возврата], [ID Книги]) 
                                   VALUES ('Выдача', 1, @Клиент, @Дата_выдачи, @Дата_возврата, @ID_Книги)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Клиент", Convert.ToInt32(comboBoxLoanReader.SelectedValue));
                    cmd.Parameters.AddWithValue("@Дата_выдачи", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Дата_возврата", DateTime.Now.AddDays(14));
                    cmd.Parameters.AddWithValue("@ID_Книги", Convert.ToInt32(comboBoxLoanBook.SelectedValue));
                    cmd.ExecuteNonQuery();
                }
                LoadLoans();
                MessageBox.Show("Книга выдана!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void buttonLoanReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoans.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            int id = Convert.ToInt32(dataGridViewLoans.CurrentRow.Cells["ID Операции"].Value);
            if (MessageBox.Show("Вернуть книгу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"UPDATE Выдача SET [Тип Операции] = 'Возврат', [Фактическая Дата Возврата] = @Дата 
                                       WHERE [ID Операции] = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadLoans();
                    MessageBox.Show("Книга возвращена!");
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        // ========== ВНУТРЕННИЕ ОПЕРАЦИИ ==========
        private void buttonOperationAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxOperationBook.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO [Внутренние Операции] ([Тип операции], Сотрудник, Дата, [ID Книги]) 
                                   VALUES (@Тип, 1, @Дата, @ID_Книги)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Тип", comboBoxOperationType.Text);
                    cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ID_Книги", Convert.ToInt32(comboBoxOperationBook.SelectedValue));
                    cmd.ExecuteNonQuery();
                }
                LoadOperations();
                MessageBox.Show("Операция добавлена!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }
    }
}