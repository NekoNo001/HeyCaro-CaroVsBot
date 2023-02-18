namespace CoCaro
{
    partial class Score
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Score));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Che_Do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chienThangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sobuocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemCoCaroBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.banDiemCoCaroDataSet3 = new CoCaro.BanDiemCoCaroDataSet3();
            this.diemCoCaroBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.banDiemCoCaroDataSet1 = new CoCaro.BanDiemCoCaroDataSet1();
            this.diemCoCaroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.banDiemCoCaroDataSet = new CoCaro.BanDiemCoCaroDataSet();
            this.diemCoCaroTableAdapter = new CoCaro.BanDiemCoCaroDataSetTableAdapters.DiemCoCaroTableAdapter();
            this.diemCoCaroTableAdapter1 = new CoCaro.BanDiemCoCaroDataSet1TableAdapters.DiemCoCaroTableAdapter();
            this.diemCoCaroTableAdapter2 = new CoCaro.BanDiemCoCaroDataSet3TableAdapters.DiemCoCaroTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Che_Do,
            this.chienThangDataGridViewTextBoxColumn,
            this.sobuocDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.diemCoCaroBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(664, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Lan_Choi";
            this.Column1.HeaderText = "Lần Chơi";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Che_Do
            // 
            this.Che_Do.DataPropertyName = "Che_Do";
            this.Che_Do.HeaderText = "Chế Độ";
            this.Che_Do.MinimumWidth = 6;
            this.Che_Do.Name = "Che_Do";
            this.Che_Do.Width = 125;
            // 
            // chienThangDataGridViewTextBoxColumn
            // 
            this.chienThangDataGridViewTextBoxColumn.DataPropertyName = "Chien_Thang";
            this.chienThangDataGridViewTextBoxColumn.HeaderText = "Chiến Thắng";
            this.chienThangDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.chienThangDataGridViewTextBoxColumn.Name = "chienThangDataGridViewTextBoxColumn";
            this.chienThangDataGridViewTextBoxColumn.Width = 125;
            // 
            // sobuocDataGridViewTextBoxColumn
            // 
            this.sobuocDataGridViewTextBoxColumn.DataPropertyName = "So_buoc";
            this.sobuocDataGridViewTextBoxColumn.HeaderText = "Số Bước";
            this.sobuocDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sobuocDataGridViewTextBoxColumn.Name = "sobuocDataGridViewTextBoxColumn";
            this.sobuocDataGridViewTextBoxColumn.Width = 125;
            // 
            // diemCoCaroBindingSource2
            // 
            this.diemCoCaroBindingSource2.DataMember = "DiemCoCaro";
            this.diemCoCaroBindingSource2.DataSource = this.banDiemCoCaroDataSet3;
            // 
            // banDiemCoCaroDataSet3
            // 
            this.banDiemCoCaroDataSet3.DataSetName = "BanDiemCoCaroDataSet3";
            this.banDiemCoCaroDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diemCoCaroBindingSource1
            // 
            this.diemCoCaroBindingSource1.DataMember = "DiemCoCaro";
            this.diemCoCaroBindingSource1.DataSource = this.banDiemCoCaroDataSet1;
            // 
            // banDiemCoCaroDataSet1
            // 
            this.banDiemCoCaroDataSet1.DataSetName = "BanDiemCoCaroDataSet1";
            this.banDiemCoCaroDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diemCoCaroBindingSource
            // 
            this.diemCoCaroBindingSource.DataMember = "DiemCoCaro";
            this.diemCoCaroBindingSource.DataSource = this.banDiemCoCaroDataSet;
            // 
            // banDiemCoCaroDataSet
            // 
            this.banDiemCoCaroDataSet.DataSetName = "BanDiemCoCaroDataSet";
            this.banDiemCoCaroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diemCoCaroTableAdapter
            // 
            this.diemCoCaroTableAdapter.ClearBeforeFill = true;
            // 
            // diemCoCaroTableAdapter1
            // 
            this.diemCoCaroTableAdapter1.ClearBeforeFill = true;
            // 
            // diemCoCaroTableAdapter2
            // 
            this.diemCoCaroTableAdapter2.ClearBeforeFill = true;
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 437);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Score";
            this.Text = "Bảng điểm";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diemCoCaroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banDiemCoCaroDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private BanDiemCoCaroDataSet banDiemCoCaroDataSet;
        private System.Windows.Forms.BindingSource diemCoCaroBindingSource;
        private BanDiemCoCaroDataSetTableAdapters.DiemCoCaroTableAdapter diemCoCaroTableAdapter;
        private BanDiemCoCaroDataSet1 banDiemCoCaroDataSet1;
        private System.Windows.Forms.BindingSource diemCoCaroBindingSource1;
        private BanDiemCoCaroDataSet1TableAdapters.DiemCoCaroTableAdapter diemCoCaroTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Che_Do;
        private System.Windows.Forms.DataGridViewTextBoxColumn chienThangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sobuocDataGridViewTextBoxColumn;
        private BanDiemCoCaroDataSet3 banDiemCoCaroDataSet3;
        private System.Windows.Forms.BindingSource diemCoCaroBindingSource2;
        private BanDiemCoCaroDataSet3TableAdapters.DiemCoCaroTableAdapter diemCoCaroTableAdapter2;
    }
}