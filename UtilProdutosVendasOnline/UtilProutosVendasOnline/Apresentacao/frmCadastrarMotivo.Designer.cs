namespace UtilProutosVendasOnline.Apresentacao
{
    partial class frmCadastrarMotivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarMotivo));
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
            this.Label16 = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.dgvMotivos = new System.Windows.Forms.DataGridView();
            this.campo_selecao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvLogLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogUsuUltimaAlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLogProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSair = new FontAwesome.Sharp.IconButton();
            this.btnGravar = new FontAwesome.Sharp.IconButton();
            this.bntExcluir = new FontAwesome.Sharp.IconButton();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(iconPictureBox1)).BeginInit();
            this.PANEI1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotivos)).BeginInit();
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
            this.PANEI1.TabIndex = 6;
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
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
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
            // Label16
            // 
            this.Label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.Label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label16.ForeColor = System.Drawing.Color.White;
            this.Label16.Location = new System.Drawing.Point(6, 84);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(386, 18);
            this.Label16.TabIndex = 147;
            this.Label16.Text = "Ultimas Cadastros";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.lblMotivo.Location = new System.Drawing.Point(8, 54);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(47, 17);
            this.lblMotivo.TabIndex = 149;
            this.lblMotivo.Text = "Motivo:";
            this.lblMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMotivo
            // 
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(57, 49);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(334, 22);
            this.txtMotivo.TabIndex = 148;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // dgvMotivos
            // 
            this.dgvMotivos.AllowDrop = true;
            this.dgvMotivos.AllowUserToAddRows = false;
            this.dgvMotivos.AllowUserToDeleteRows = false;
            this.dgvMotivos.AllowUserToOrderColumns = true;
            this.dgvMotivos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.dgvMotivos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMotivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMotivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMotivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvMotivos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvMotivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMotivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMotivos.ColumnHeadersHeight = 20;
            this.dgvMotivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.campo_selecao,
            this.dgvLogLoja,
            this.dgvLogUsuUltimaAlt,
            this.dgvLogProduto});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMotivos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMotivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMotivos.EnableHeadersVisualStyles = false;
            this.dgvMotivos.GridColor = System.Drawing.Color.DarkGray;
            this.dgvMotivos.Location = new System.Drawing.Point(6, 103);
            this.dgvMotivos.Name = "dgvMotivos";
            this.dgvMotivos.ReadOnly = true;
            this.dgvMotivos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMotivos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMotivos.RowHeadersVisible = false;
            this.dgvMotivos.RowHeadersWidth = 20;
            this.dgvMotivos.RowTemplate.Height = 20;
            this.dgvMotivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMotivos.Size = new System.Drawing.Size(386, 160);
            this.dgvMotivos.TabIndex = 150;
            this.dgvMotivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMotivos_CellContentClick);
            this.dgvMotivos.SelectionChanged += new System.EventHandler(this.dgvMotivos_SelectionChanged);
            // 
            // campo_selecao
            // 
            this.campo_selecao.DataPropertyName = "campo_selecao";
            this.campo_selecao.HeaderText = "";
            this.campo_selecao.Name = "campo_selecao";
            this.campo_selecao.ReadOnly = true;
            this.campo_selecao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.campo_selecao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.campo_selecao.Width = 20;
            // 
            // dgvLogLoja
            // 
            this.dgvLogLoja.DataPropertyName = "mmp_motivo_VC";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLogLoja.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogLoja.HeaderText = "Motivo";
            this.dgvLogLoja.Name = "dgvLogLoja";
            this.dgvLogLoja.ReadOnly = true;
            this.dgvLogLoja.Width = 180;
            // 
            // dgvLogUsuUltimaAlt
            // 
            this.dgvLogUsuUltimaAlt.DataPropertyName = "mmp_usuariocriacao_VC";
            this.dgvLogUsuUltimaAlt.HeaderText = "Usuário";
            this.dgvLogUsuUltimaAlt.Name = "dgvLogUsuUltimaAlt";
            this.dgvLogUsuUltimaAlt.ReadOnly = true;
            // 
            // dgvLogProduto
            // 
            this.dgvLogProduto.DataPropertyName = "mmp_datacriacao_DT";
            this.dgvLogProduto.HeaderText = "Data ";
            this.dgvLogProduto.Name = "dgvLogProduto";
            this.dgvLogProduto.ReadOnly = true;
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
            this.btnSair.Location = new System.Drawing.Point(316, 269);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(76, 34);
            this.btnSair.TabIndex = 151;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.btnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGravar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGravar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGravar.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGravar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGravar.IconSize = 24;
            this.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGravar.Location = new System.Drawing.Point(152, 269);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(76, 34);
            this.btnGravar.TabIndex = 152;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // bntExcluir
            // 
            this.bntExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(63)))));
            this.bntExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntExcluir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntExcluir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bntExcluir.IconChar = FontAwesome.Sharp.IconChar.X;
            this.bntExcluir.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntExcluir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bntExcluir.IconSize = 24;
            this.bntExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntExcluir.Location = new System.Drawing.Point(234, 269);
            this.bntExcluir.Name = "bntExcluir";
            this.bntExcluir.Size = new System.Drawing.Size(76, 34);
            this.bntExcluir.TabIndex = 153;
            this.bntExcluir.Text = "Excluir";
            this.bntExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bntExcluir.UseVisualStyleBackColor = false;
            this.bntExcluir.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmCadastrarMotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 312);
            this.Controls.Add(this.bntExcluir);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dgvMotivos);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.PANEI1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadastrarMotivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCadastrarMotivo";
            this.Load += new System.EventHandler(this.frmCadastrarMotivo_Load);
            ((System.ComponentModel.ISupportInitialize)(iconPictureBox1)).EndInit();
            this.PANEI1.ResumeLayout(false);
            this.PANEI1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PANEI1;
        internal System.Windows.Forms.Button btnMinimizar;
        internal System.Windows.Forms.Button btnMaximizar;
        internal System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label lblMotivo;
        internal System.Windows.Forms.TextBox txtMotivo;
        internal System.Windows.Forms.DataGridView dgvMotivos;
        private FontAwesome.Sharp.IconButton btnSair;
        private FontAwesome.Sharp.IconButton btnGravar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn campo_selecao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogUsuUltimaAlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLogProduto;
        private FontAwesome.Sharp.IconButton bntExcluir;
    }
}