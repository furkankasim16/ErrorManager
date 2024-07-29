namespace ErrorUI
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorcodeclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryclmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsrchbycode = new System.Windows.Forms.Button();
            this.btnsrchbydesc = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idclmn,
            this.errorcodeclmn,
            this.descriptionclmn,
            this.categoryclmn});
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1088, 773);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idclmn
            // 
            this.idclmn.HeaderText = "Id";
            this.idclmn.MinimumWidth = 6;
            this.idclmn.Name = "idclmn";
            this.idclmn.Width = 125;
            // 
            // errorcodeclmn
            // 
            this.errorcodeclmn.HeaderText = "ErrorCode";
            this.errorcodeclmn.MinimumWidth = 6;
            this.errorcodeclmn.Name = "errorcodeclmn";
            this.errorcodeclmn.Width = 125;
            // 
            // descriptionclmn
            // 
            this.descriptionclmn.HeaderText = "Description";
            this.descriptionclmn.MinimumWidth = 6;
            this.descriptionclmn.Name = "descriptionclmn";
            this.descriptionclmn.Width = 190;
            // 
            // categoryclmn
            // 
            this.categoryclmn.HeaderText = "Category";
            this.categoryclmn.MinimumWidth = 6;
            this.categoryclmn.Name = "categoryclmn";
            this.categoryclmn.Width = 125;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1146, 185);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(285, 52);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1144, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1289, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 22);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1143, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "ErrorCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1286, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1144, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // btnsrchbycode
            // 
            this.btnsrchbycode.Location = new System.Drawing.Point(1143, 264);
            this.btnsrchbycode.Name = "btnsrchbycode";
            this.btnsrchbycode.Size = new System.Drawing.Size(140, 63);
            this.btnsrchbycode.TabIndex = 7;
            this.btnsrchbycode.Text = "SearchByCode";
            this.btnsrchbycode.UseVisualStyleBackColor = true;
            this.btnsrchbycode.Click += new System.EventHandler(this.SrchByCode);
            // 
            // btnsrchbydesc
            // 
            this.btnsrchbydesc.Location = new System.Drawing.Point(1289, 264);
            this.btnsrchbydesc.Name = "btnsrchbydesc";
            this.btnsrchbydesc.Size = new System.Drawing.Size(145, 63);
            this.btnsrchbydesc.TabIndex = 8;
            this.btnsrchbydesc.Text = "SearchByDescription";
            this.btnsrchbydesc.UseVisualStyleBackColor = true;
            this.btnsrchbydesc.Click += new System.EventHandler(this.SrchByDesc);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(1146, 355);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(93, 58);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.Add);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(1245, 355);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(93, 58);
            this.btnupdate.TabIndex = 10;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.Update);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(1341, 355);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(93, 58);
            this.btndelete.TabIndex = 11;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.Delete);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1147, 109);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(73, 22);
            this.textBox3.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1150, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Id";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(1147, 437);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(92, 44);
            this.btnrefresh.TabIndex = 14;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.Refresh);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(1245, 437);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(93, 44);
            this.btnsearch.TabIndex = 15;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.Search);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 773);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnsrchbydesc);
            this.Controls.Add(this.btnsrchbycode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsrchbycode;
        private System.Windows.Forms.Button btnsrchbydesc;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorcodeclmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionclmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryclmn;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnsearch;
    }
}

