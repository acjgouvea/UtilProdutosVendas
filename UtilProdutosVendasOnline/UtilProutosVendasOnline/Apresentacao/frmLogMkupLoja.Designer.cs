using UtilProutosVendasOnline.Apresentacao;

namespace UtilitarioProdutosVendasOnline.Apresentacao
{
    partial class frmLogMkupLoja
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
            FontAwesome.Sharp.IconPictureBox iconPictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogMkupLoja));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PANEI1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSair = new FontAwesome.Sharp.IconButton();
            this.dgvLogMkup = new System.Windows.Forms.DataGridView();
            this.Label16 = new System.Windows.Forms.Label();
            this.dgvLogLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogUsuUltimaAlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogMkupPadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(iconPictureBox1)).BeginInit();
            this.PANEI1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogMkup)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(186)))), ((int)(((byte)(16)))));
            iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.FileText;
            iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 22;
            iconPictureBox1.Location = new System.Drawing.Point(6, 5);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new System.Drawing.Size(24, 22);
            iconPictureBox1.TabIndex = 128;
            iconPictureBox1.TabStop = false;
            // 
            // PANEI1
            // 
            this.PANEI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PANEI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(186)))), ((int)(((byte)(16)))));
            this.PANEI1.Controls.Add(iconPictureBox1);
            this.PANEI1.Controls.Add(this.btnMinimizar);
            this.PANEI1.Controls.Add(this.btnMaximizar);
            this.PANEI1.Controls.Add(this.btnFechar);
            this.PANEI1.Controls.Add(this.label1);
            this.PANEI1.Location = new System.Drawing.Point(0, 0);
            this.PANEI1.Name = "PANEI1";
            this.PANEI1.Size = new System.Drawing.Size(400, 32);
            this.PANEI1.TabIndex = 7;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(302, 2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(28, 28);
            this.btnMinimizar.TabIndex = 124;
            this.btnMinimizar.Text = "";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizar.ForeColor = System.Drawing.Color.White;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(336, 2);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(28, 28);
            this.btnMaximizar.TabIndex = 125;
            this.btnMaximizar.Text = "";
            this.btnMaximizar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(186)))), ((int)(((byte)(16)))));
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(367, 2);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(28, 28);
            this.btnFechar.TabIndex = 68;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(34, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Utilitário Produtos Vendas Online";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Red;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSair.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.btnSair.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSair.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSair.IconSize = 24;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.Location = new System.Drawing.Point(317, 271);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(76, 34);
            this.btnSair.TabIndex = 153;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dgvLogMkup
            // 
            this.dgvLogMkup.AllowDrop = true;
            this.dgvLogMkup.AllowUserToAddRows = false;
            this.dgvLogMkup.AllowUserToDeleteRows = false;
            this.dgvLogMkup.AllowUserToOrderColumns = true;
            this.dgvLogMkup.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dgvLogMkup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogMkup.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogMkup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogMkup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvLogMkup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvLogMkup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogMkup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogMkup.ColumnHeadersHeight = 20;
            this.dgvLogMkup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLogLoja,
            this.dgvLogData,
            this.dgvLogUsuUltimaAlt,
            this.dgvLogMkupPadrao});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogMkup.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLogMkup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLogMkup.EnableHeadersVisualStyles = false;
            this.dgvLogMkup.GridColor = System.Drawing.Color.DarkGray;
            this.dgvLogMkup.Location = new System.Drawing.Point(7, 75);
            this.dgvLogMkup.Name = "dgvLogMkup";
            this.dgvLogMkup.ReadOnly = true;
            this.dgvLogMkup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogMkup.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLogMkup.RowHeadersVisible = false;
            this.dgvLogMkup.RowHeadersWidth = 20;
            this.dgvLogMkup.RowTemplate.Height = 20;
            this.dgvLogMkup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogMkup.Size = new System.Drawing.Size(386, 190);
            this.dgvLogMkup.TabIndex = 152;
            // 
            // Label16
            // 
            this.Label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.Label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label16.ForeColor = System.Drawing.Color.White;
            this.Label16.Location = new System.Drawing.Point(7, 53);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(386, 18);
            this.Label16.TabIndex = 154;
            this.Label16.Text = "Ultimas Alterações";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLogLoja
            // 
            this.dgvLogLoja.DataPropertyName = "loj_loja_IN";
            this.dgvLogLoja.HeaderText = "Loja";
            this.dgvLogLoja.Name = "dgvLogLoja";
            this.dgvLogLoja.ReadOnly = true;
            this.dgvLogLoja.Width = 85;
            // 
            // dgvLogData
            // 
            this.dgvLogData.DataPropertyName = "Data_Log";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLogData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogData.HeaderText = "Data";
            this.dgvLogData.Name = "dgvLogData";
            this.dgvLogData.ReadOnly = true;
            this.dgvLogData.Width = 120;
            // 
            // dgvLogUsuUltimaAlt
            // 
            this.dgvLogUsuUltimaAlt.DataPropertyName = "Usuario_Log";
            this.dgvLogUsuUltimaAlt.HeaderText = "Usuário";
            this.dgvLogUsuUltimaAlt.Name = "dgvLogUsuUltimaAlt";
            this.dgvLogUsuUltimaAlt.ReadOnly = true;
            // 
            // dgvLogMkupPadrao
            // 
            this.dgvLogMkupPadrao.DataPropertyName = "MkupPadrao";
            this.dgvLogMkupPadrao.HeaderText = "Mkup %";
            this.dgvLogMkupPadrao.Name = "dgvLogMkupPadrao";
            this.dgvLogMkupPadrao.ReadOnly = true;
            this.dgvLogMkupPadrao.Width = 80;
            // 
            // frmLogMkupLoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 312);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dgvLogMkup);
            this.Controls.Add(this.PANEI1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogMkupLoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogMkupLoja";
            this.Load += new System.EventHandler(this.frmLogMkupLoja_Load);
            ((System.ComponentModel.ISupportInitialize)(iconPictureBox1)).EndInit();
            this.PANEI1.ResumeLayout(false);
            this.PANEI1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogMkup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogMkupLoja));
        private System.Windows.Forms.Panel PANEI1;
        internal System.Windows.Forms.Button btnMinimizar;
        internal System.Windows.Forms.Button btnMaximizar;
        internal System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnSair;
        internal System.Windows.Forms.DataGridView dgvLogMkup;
        internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogUsuUltimaAlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogMkupPadrao;
    }
}