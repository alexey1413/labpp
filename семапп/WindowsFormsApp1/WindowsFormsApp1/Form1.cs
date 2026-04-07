using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.OleDb;

namespace Biblioteka

{
    public partial class Form1 : Form
    {
        
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\pvz save\library1.accdb";

        // Запросы для загрузки данных
        private string booksQuery = "SELECT ID, Название, ФИО_автора, Дата_написания, Жанр, Стоимость FROM Книги";
        private string readersQuery = "SELECT ID, ФИО, Личная_информация FROM Читатель";
        private string employeesQuery = "SELECT ID_Сотрудника AS ID, ФИО, Возраст FROM Сотрудник";
        private string loansQuery = @"SELECT Выдача.ID_Операции, Книги.Название AS Книга, Читатель.ФИО AS Читатель, 
                                      Сотрудник.ФИО AS Оператор, Выдача.Дата_выдачи, Выдача.Дата_возврата, 
                                      Выдача.Фактическая_дата_возврата, Выдача.Тип_операции
                                      FROM ((Выдача 
                                      INNER JOIN Книги ON Выдача.ID_Книги = Книги.ID) 
                                      INNER JOIN Читатель ON Выдача.Клиент = Читатель.ID) 
                                      INNER JOIN Сотрудник ON Выдача.Оператор = Сотрудник.ID_Сотрудника
                                      ORDER BY Выдача.ID_Операции DESC";

        private string operationsQuery = @"SELECT Внутренние_Операции.ID, Внутренние_Операции.Тип_операции, 
                                           Сотрудник.ФИО AS Сотрудник, Внутренние_Операции.Дата, Книги.Название AS Книга
                                           FROM (Внутренние_Операции 
                                           INNER JOIN Сотрудник ON Внутренние_Операции.Сотрудник = Сотрудник.ID_Сотрудника) 
                                           INNER JOIN Книги ON Внутренние_Операции.ID_Книги = Книги.ID
                                           ORDER BY Внутренние_Операции.ID DESC";

        public Form1()
        {
            InitializeComponent();
            // Подписываем события на кнопки
            buttonBookAdd.Click += ButtonBookAdd_Click;
            buttonBookUpdate.Click += ButtonBookUpdate_Click;
            buttonBookDelete.Click += ButtonBookDelete_Click;

            buttonReaderAdd.Click += ButtonReaderAdd_Click;
            buttonReaderUpdate.Click += ButtonReaderUpdate_Click;
            buttonReaderDelete.Click += ButtonReaderDelete_Click;

            buttonEmployeeAdd.Click += ButtonEmployeeAdd_Click;
            buttonEmployeeUpdate.Click += ButtonEmployeeUpdate_Click;
            buttonEmployeeDelete.Click += ButtonEmployeeDelete_Click;

            buttonLoanIssue.Click += ButtonLoanIssue_Click;
            buttonLoanReturn.Click += ButtonLoanReturn_Click;

            buttonOperationAdd.Click += ButtonOperationAdd_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Загружаем жанры в ComboBox
            LoadGenres();

            // Загружаем все данные
            LoadBooks();
            LoadReaders();
            LoadEmployees();
            LoadLoans();
            LoadOperations();

            // Загружаем данные для ComboBox
            LoadComboBoxData("SELECT ID, Название FROM Книги", "Название", "ID", comboBoxLoanBook);
            LoadComboBoxData("SELECT ID, ФИО FROM Читатель", "ФИО", "ID", comboBoxLoanReader);
            LoadComboBoxData("SELECT ID_Сотрудника, ФИО FROM Сотрудник", "ФИО", "ID_Сотрудника", comboBoxLoanEmployee);
            LoadComboBoxData("SELECT ID, Название FROM Книги", "Название", "ID", comboBoxOperationBook);
            LoadComboBoxData("SELECT ID_Сотрудника, ФИО FROM Сотрудник", "ФИО", "ID_Сотрудника", comboBoxOperationEmployee);

            // Скрываем ID колонки
            HideIDColumn(dataGridViewBooks, "ID");
            HideIDColumn(dataGridViewReaders, "ID");
            HideIDColumn(dataGridViewEmployees, "ID");
            HideIDColumn(dataGridViewLoans, "ID_Операции");
            HideIDColumn(dataGridViewOperations, "ID");
        }

        private void LoadGenres()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Жанр FROM Книги WHERE Жанр IS NOT NULL";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxGenre.Items.Clear();
                    comboBoxGenre.Items.Add(""); // Пустой вариант
                    foreach (DataRow row in dt.Rows)
                    {
                        comboBoxGenre.Items.Add(row["Жанр"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки жанров: " + ex.Message);
            }
        }

        private void LoadBooks()
        {
            DataLoad(booksQuery, dataGridViewBooks);
        }

        private void LoadReaders()
        {
            DataLoad(readersQuery, dataGridViewReaders);
        }

        private void LoadEmployees()
        {
            DataLoad(employeesQuery, dataGridViewEmployees);
        }

        private void LoadLoans()
        {
            DataLoad(loansQuery, dataGridViewLoans);
        }

        private void LoadOperations()
        {
            DataLoad(operationsQuery, dataGridViewOperations);
        }

        private void DataLoad(string query, DataGridView grid)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            grid.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void LoadComboBoxData(string query, string display, string value, ComboBox box)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            box.DataSource = dataTable;
                            box.DisplayMember = display;
                            box.ValueMember = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки списка: " + ex.Message);
            }
        }

        private void HideIDColumn(DataGridView grid, string columnName)
        {
            if (grid.Columns[columnName] != null)
            {
                grid.Columns[columnName].Visible = false;
            }
        }

        // ==================== РАБОТА С КНИГАМИ ====================

        private void ButtonBookAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookName.Text))
            {
                MessageBox.Show("Введите название книги!");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Книги (Название, ФИО_автора, Дата_написания, Жанр, Стоимость) 
                                   VALUES (@Название, @Автор, @Дата, @Жанр, @Стоимость)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Название", textBoxBookName.Text);
                    cmd.Parameters.AddWithValue("@Автор", "Не указан"); // Можно добавить поле для автора
                    cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Жанр", comboBoxGenre.Text);
                    cmd.Parameters.AddWithValue("@Стоимость", 0);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Книга добавлена!");
                    LoadBooks();
                    textBoxBookName.Clear();
                    LoadGenres();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonBookUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу для изменения!");
                return;
            }

            int bookId = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID"].Value);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Книги SET Название = @Название, Жанр = @Жанр 
                                   WHERE ID = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Название", textBoxBookName.Text);
                    cmd.Parameters.AddWithValue("@Жанр", comboBoxGenre.Text);
                    cmd.Parameters.AddWithValue("@ID", bookId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Книга изменена!");
                    LoadBooks();
                    textBoxBookName.Clear();
                    LoadGenres();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonBookDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу для удаления!");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить книгу?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int bookId = Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["ID"].Value);

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Книги WHERE ID = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", bookId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Книга удалена!");
                        LoadBooks();
                        LoadGenres();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== РАБОТА С ЧИТАТЕЛЯМИ ====================

        private void ButtonReaderAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxReaderName.Text))
            {
                MessageBox.Show("Введите ФИО читателя!");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Читатель (ФИО, Личная_информация) VALUES (@ФИО, @Инфо)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxReaderName.Text);
                    cmd.Parameters.AddWithValue("@Инфо", textBoxReaderInfo.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Читатель добавлен!");
                    LoadReaders();
                    textBoxReaderName.Clear();
                    textBoxReaderInfo.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonReaderUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null)
            {
                MessageBox.Show("Выберите читателя для изменения!");
                return;
            }

            int readerId = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID"].Value);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Читатель SET ФИО = @ФИО, Личная_информация = @Инфо WHERE ID = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxReaderName.Text);
                    cmd.Parameters.AddWithValue("@Инфо", textBoxReaderInfo.Text);
                    cmd.Parameters.AddWithValue("@ID", readerId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные читателя изменены!");
                    LoadReaders();
                    textBoxReaderName.Clear();
                    textBoxReaderInfo.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonReaderDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReaders.CurrentRow == null)
            {
                MessageBox.Show("Выберите читателя для удаления!");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить читателя?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int readerId = Convert.ToInt32(dataGridViewReaders.CurrentRow.Cells["ID"].Value);

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Читатель WHERE ID = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", readerId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Читатель удален!");
                        LoadReaders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== РАБОТА С СОТРУДНИКАМИ ====================

        private void ButtonEmployeeAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmployeeName.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника!");
                return;
            }

            int age = 0;
            if (!string.IsNullOrWhiteSpace(textBoxEmployeeAge.Text))
            {
                if (!int.TryParse(textBoxEmployeeAge.Text, out age))
                {
                    MessageBox.Show("Возраст должен быть числом!");
                    return;
                }
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Сотрудник (ФИО, Возраст) VALUES (@ФИО, @Возраст)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@Возраст", age);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Сотрудник добавлен!");
                    LoadEmployees();
                    textBoxEmployeeName.Clear();
                    textBoxEmployeeAge.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonEmployeeUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника для изменения!");
                return;
            }

            int employeeId = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID"].Value);

            int age = 0;
            if (!string.IsNullOrWhiteSpace(textBoxEmployeeAge.Text))
            {
                if (!int.TryParse(textBoxEmployeeAge.Text, out age))
                {
                    MessageBox.Show("Возраст должен быть числом!");
                    return;
                }
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Сотрудник SET ФИО = @ФИО, Возраст = @Возраст WHERE ID_Сотрудника = @ID";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ФИО", textBoxEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@Возраст", age);
                    cmd.Parameters.AddWithValue("@ID", employeeId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные сотрудника изменены!");
                    LoadEmployees();
                    textBoxEmployeeName.Clear();
                    textBoxEmployeeAge.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonEmployeeDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления!");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить сотрудника?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int employeeId = Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["ID"].Value);

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Сотрудник WHERE ID_Сотрудника = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", employeeId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Сотрудник удален!");
                        LoadEmployees();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        // ==================== ВЫДАЧА КНИГ ====================

        private void ButtonLoanIssue_Click(object sender, EventArgs e)
        {
            if (comboBoxLoanBook.SelectedValue == null ||
                comboBoxLoanReader.SelectedValue == null ||
                comboBoxLoanEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите книгу, читателя и сотрудника!");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Выдача (Тип_операции, Оператор, Клиент, Дата_выдачи, Дата_возврата, ID_Книги) 
                                   VALUES ('Выдача', @Оператор, @Клиент, @Дата_выдачи, @Дата_возврата, @ID_Книги)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Оператор", Convert.ToInt32(comboBoxLoanEmployee.SelectedValue));
                    cmd.Parameters.AddWithValue("@Клиент", Convert.ToInt32(comboBoxLoanReader.SelectedValue));
                    cmd.Parameters.AddWithValue("@Дата_выдачи", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Дата_возврата", DateTime.Now.AddDays(14));
                    cmd.Parameters.AddWithValue("@ID_Книги", Convert.ToInt32(comboBoxLoanBook.SelectedValue));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Книга выдана! Дата возврата: " + DateTime.Now.AddDays(14).ToShortDateString());
                    LoadLoans();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выдаче: " + ex.Message);
            }
        }

        private void ButtonLoanReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewLoans.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись о выдаче для возврата!");
                return;
            }

            int loanId = Convert.ToInt32(dataGridViewLoans.CurrentRow.Cells["ID_Операции"].Value);
            string bookName = dataGridViewLoans.CurrentRow.Cells["Книга"].Value.ToString();

            DialogResult result = MessageBox.Show($"Вернуть книгу '{bookName}'?", "Подтверждение возврата",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"UPDATE Выдача SET Тип_операции = 'Возврат', Фактическая_дата_возврата = @Дата 
                                       WHERE ID_Операции = @ID";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ID", loanId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Книга возвращена!");
                        LoadLoans();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при возврате: " + ex.Message);
                }
            }
        }

        // ==================== ВНУТРЕННИЕ ОПЕРАЦИИ ====================

        private void ButtonOperationAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxOperationBook.SelectedValue == null ||
                comboBoxOperationEmployee.SelectedValue == null ||
                string.IsNullOrWhiteSpace(comboBoxOperationType.Text))
            {
                MessageBox.Show("Выберите книгу, сотрудника и тип операции!");
                return;
            }

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Внутренние_Операции (Тип_операции, Сотрудник, Дата, ID_Книги) 
                                   VALUES (@Тип, @Сотрудник, @Дата, @ID_Книги)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Тип", comboBoxOperationType.Text);
                    cmd.Parameters.AddWithValue("@Сотрудник", Convert.ToInt32(comboBoxOperationEmployee.SelectedValue));
                    cmd.Parameters.AddWithValue("@Дата", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ID_Книги", Convert.ToInt32(comboBoxOperationBook.SelectedValue));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Операция добавлена!");
                    LoadOperations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}