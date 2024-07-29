using ErrorAPI.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorUI
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetAllErrors();
        }

        private async Task GetAllErrors()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:7165/api/errors/all");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<List<ErrorDto>>(result);
                SetupDataGridView();
                dataGridView1.DataSource = errors;
            }
            else
            {
                MessageBox.Show("Error: " + response.ReasonPhrase);
            }
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ErrorCode",
                HeaderText = "Error Code",
                DataPropertyName = "ErrorCode",
                Width = 100
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Description",
                DataPropertyName = "Description",
                Width = 400
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category",
                Width = 100
            });
        }

        private async void SrchByCode(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Bu işlem için ErrorCode alanının doldurulması gereklidir");
                    return;
                }
                string code = Uri.EscapeDataString(textBox1.Text); // URL encode
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7165/api/errors/byCode?errorCode={code}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var errors = JsonConvert.DeserializeObject<List<ErrorDto>>(result);

                    // Clear existing columns
                    dataGridView1.Columns.Clear();

                    // Re-setup DataGridView columns
                    SetupDataGridView();

                    // Bind data to DataGridView
                    dataGridView1.DataSource = errors;
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void SrchByDesc(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("Bu işlem için Description alanının doldurulması gereklidir");
                    return;
                }
                string description = Uri.EscapeDataString(richTextBox1.Text); // URL encode
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7165/api/errors/byDescription?description={description}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var errors = JsonConvert.DeserializeObject<List<ErrorDto>>(result);

                    // Clear existing columns
                    dataGridView1.Columns.Clear();

                    // Re-setup DataGridView columns
                    SetupDataGridView();

                    // Bind data to DataGridView
                    dataGridView1.DataSource = errors;
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void Add(object sender, EventArgs e)
        {
            try
            {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("bu işlem için tüm alanların doldurulması gereklidir");
                return;
            }
            var error = new ErrorDto
                {
                    ErrorCode = textBox1.Text,
                    Description = richTextBox1.Text,
                    Category = textBox2.Text
                };
                var content = new StringContent(JsonConvert.SerializeObject(error), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:7165/api/errors", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error created successfully.");
                    await GetAllErrors(); // Refresh the DataGridView
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void Update(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox3.Text);
                var error = new ErrorDto
                {
                    Id = id,
                    ErrorCode = textBox1.Text,
                    Description = richTextBox1.Text,
                    Category = textBox2.Text
                };
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text)|| string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("bu işlem için tüm alanların doldurulması gereklidir");
                    return;
                }
                var content = new StringContent(JsonConvert.SerializeObject(error), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"https://localhost:7165/api/errors/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error updated successfully.");
                    await GetAllErrors(); // Refresh the DataGridView
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void Delete(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text) == null)
                {
                    MessageBox.Show("Bu işlem için bir ID girmeniz gerekmetedir.Lütfen ID giriniz.");
                    return;
                }
                int id = Convert.ToInt32(textBox3.Text);
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7165/api/errors/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error deleted successfully.");
                    await GetAllErrors(); // Refresh the DataGridView
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{responseBody}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Refresh(object sender, EventArgs e)
        {
            GetAllErrors();
        }

        private async void Search(object sender, EventArgs e)
        {
            try
            {
                string code = textBox1.Text.Trim();
                string description = richTextBox1.Text.Trim();
                string category = textBox2.Text.Trim();

                string url = "https://localhost:7165/api/errors/filter?";

                // URL oluşturulurken sadece dolu olan parametreler eklenir
                if (!string.IsNullOrEmpty(code))
                {
                    url += $"errorCode={Uri.EscapeDataString(code)}&";
                }
                if (!string.IsNullOrEmpty(description))
                {
                    url += $"description={Uri.EscapeDataString(description)}&";
                }
                if (!string.IsNullOrEmpty(category))
                {
                    url += $"category={Uri.EscapeDataString(category)}&";
                }

                // "&" işaretinden sonrasını temizle
                url = url.TrimEnd('&');

                // Eğer URL boşsa, API'den tüm verileri al
                if (string.IsNullOrEmpty(url) || url.EndsWith("?"))
                {
                    url = "https://localhost:7165/api/errors/all";
                }

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var errors = JsonConvert.DeserializeObject<List<ErrorDto>>(result);

                    // Clear existing columns
                    dataGridView1.Columns.Clear();

                    // Re-setup DataGridView columns
                    SetupDataGridView();

                    // Bind data to DataGridView
                    dataGridView1.DataSource = errors;
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}\n{await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer başlık satırı tıklanmışsa, hiçbir şey yapma
            if (e.RowIndex == -1)
            {
                return;
            }

            // Seçili satırın verilerini al
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            // Verileri ilgili TextBox ve RichTextBox kontrollerine doldur
            textBox3.Text = selectedRow.Cells["Id"].Value.ToString();
            textBox1.Text = selectedRow.Cells["ErrorCode"].Value.ToString();
            richTextBox1.Text = selectedRow.Cells["Description"].Value.ToString();
            textBox2.Text = selectedRow.Cells["Category"].Value.ToString();
        }
    }
}
    