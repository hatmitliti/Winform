
namespace QuanLiThongTinSinhVien_NDT
{
    partial class frmdangnhap
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
            this.lbldangnhap = new System.Windows.Forms.Label();
            this.lbltaikhoandangnhap = new System.Windows.Forms.Label();
            this.lblmatkhaudangnhap = new System.Windows.Forms.Label();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbldangnhap
            // 
            this.lbldangnhap.AutoSize = true;
            this.lbldangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldangnhap.Location = new System.Drawing.Point(187, 26);
            this.lbldangnhap.Name = "lbldangnhap";
            this.lbldangnhap.Size = new System.Drawing.Size(175, 36);
            this.lbldangnhap.TabIndex = 0;
            this.lbldangnhap.Text = "Đăng Nhập";
            // 
            // lbltaikhoandangnhap
            // 
            this.lbltaikhoandangnhap.AutoSize = true;
            this.lbltaikhoandangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaikhoandangnhap.Location = new System.Drawing.Point(46, 102);
            this.lbltaikhoandangnhap.Name = "lbltaikhoandangnhap";
            this.lbltaikhoandangnhap.Size = new System.Drawing.Size(82, 17);
            this.lbltaikhoandangnhap.TabIndex = 1;
            this.lbltaikhoandangnhap.Text = "Tài Khoản";
            // 
            // lblmatkhaudangnhap
            // 
            this.lblmatkhaudangnhap.AutoSize = true;
            this.lblmatkhaudangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmatkhaudangnhap.Location = new System.Drawing.Point(46, 152);
            this.lblmatkhaudangnhap.Name = "lblmatkhaudangnhap";
            this.lblmatkhaudangnhap.Size = new System.Drawing.Size(76, 17);
            this.lblmatkhaudangnhap.TabIndex = 3;
            this.lblmatkhaudangnhap.Text = "Mật Khẩu";
            // 
            // txtDangNhap
            // 
            this.txtDangNhap.Location = new System.Drawing.Point(168, 102);
            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(325, 22);
            this.txtDangNhap.TabIndex = 2;
            this.txtDangNhap.TextChanged += new System.EventHandler(this.txtDangNhap_TextChanged);
            // 
            // btndangnhap
            // 
            this.btndangnhap.Location = new System.Drawing.Point(268, 205);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(94, 38);
            this.btndangnhap.TabIndex = 5;
            this.btndangnhap.Text = "Đăng Nhập";
            this.btndangnhap.UseVisualStyleBackColor = true;
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(407, 205);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(86, 38);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(168, 152);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(325, 22);
            this.txtmatkhau.TabIndex = 4;
            this.txtmatkhau.TextChanged += new System.EventHandler(this.txtmatkhau_TextChanged);
            // 
            // frmdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(545, 274);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndangnhap);
            this.Controls.Add(this.txtmatkhau);
            this.Controls.Add(this.txtDangNhap);
            this.Controls.Add(this.lblmatkhaudangnhap);
            this.Controls.Add(this.lbltaikhoandangnhap);
            this.Controls.Add(this.lbldangnhap);
            this.Name = "frmdangnhap";
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldangnhap;
        private System.Windows.Forms.Label lbltaikhoandangnhap;
        private System.Windows.Forms.Label lblmatkhaudangnhap;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.TextBox txtmatkhau;
    }
}