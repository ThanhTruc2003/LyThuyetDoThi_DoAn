namespace LyThuyetDoThi
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Graph = new Panel();
            txb_KetLuan = new TextBox();
            panel_Feature = new Panel();
            label8 = new Label();
            bt_Refresh = new Button();
            txbTrongSo = new TextBox();
            txb_Prim = new TextBox();
            txb_DinhCuoiCuaFord = new TextBox();
            label7 = new Label();
            txb_DinhDauCuaFord = new TextBox();
            label6 = new Label();
            txbDinhCuoiCanXoa = new TextBox();
            label5 = new Label();
            txbDinhDauCanXoa = new TextBox();
            label4 = new Label();
            txbDinhDau = new TextBox();
            bt_xoaCanh = new Button();
            txbDinhCuoi = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            bt_xoaDinh = new Button();
            bt_themCanh = new Button();
            txbXoaDinh = new TextBox();
            bt_XoaDoThi = new Button();
            txbThemDinh = new TextBox();
            bt_DocFile = new Button();
            bt_XetLienThong = new Button();
            bt_themDinh = new Button();
            bt_Prim = new Button();
            bt_Ford = new Button();
            panel_Graph.SuspendLayout();
            panel_Feature.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Graph
            // 
            panel_Graph.Controls.Add(txb_KetLuan);
            panel_Graph.Location = new Point(14, 16);
            panel_Graph.Margin = new Padding(3, 4, 3, 4);
            panel_Graph.Name = "panel_Graph";
            panel_Graph.Size = new Size(786, 781);
            panel_Graph.TabIndex = 0;
            panel_Graph.Paint += panel_Graph_Paint;
            // 
            // txb_KetLuan
            // 
            txb_KetLuan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txb_KetLuan.Location = new Point(3, 705);
            txb_KetLuan.Margin = new Padding(3, 4, 3, 4);
            txb_KetLuan.Multiline = true;
            txb_KetLuan.Name = "txb_KetLuan";
            txb_KetLuan.ReadOnly = true;
            txb_KetLuan.Size = new Size(779, 71);
            txb_KetLuan.TabIndex = 0;
            // 
            // panel_Feature
            // 
            panel_Feature.Controls.Add(label8);
            panel_Feature.Controls.Add(bt_Refresh);
            panel_Feature.Controls.Add(txbTrongSo);
            panel_Feature.Controls.Add(txb_Prim);
            panel_Feature.Controls.Add(txb_DinhCuoiCuaFord);
            panel_Feature.Controls.Add(label7);
            panel_Feature.Controls.Add(txb_DinhDauCuaFord);
            panel_Feature.Controls.Add(label6);
            panel_Feature.Controls.Add(txbDinhCuoiCanXoa);
            panel_Feature.Controls.Add(label5);
            panel_Feature.Controls.Add(txbDinhDauCanXoa);
            panel_Feature.Controls.Add(label4);
            panel_Feature.Controls.Add(txbDinhDau);
            panel_Feature.Controls.Add(bt_xoaCanh);
            panel_Feature.Controls.Add(txbDinhCuoi);
            panel_Feature.Controls.Add(label3);
            panel_Feature.Controls.Add(label2);
            panel_Feature.Controls.Add(label1);
            panel_Feature.Controls.Add(bt_xoaDinh);
            panel_Feature.Controls.Add(bt_themCanh);
            panel_Feature.Controls.Add(txbXoaDinh);
            panel_Feature.Controls.Add(bt_XoaDoThi);
            panel_Feature.Controls.Add(txbThemDinh);
            panel_Feature.Controls.Add(bt_DocFile);
            panel_Feature.Controls.Add(bt_XetLienThong);
            panel_Feature.Controls.Add(bt_themDinh);
            panel_Feature.Controls.Add(bt_Prim);
            panel_Feature.Controls.Add(bt_Ford);
            panel_Feature.Location = new Point(824, 16);
            panel_Feature.Margin = new Padding(3, 4, 3, 4);
            panel_Feature.Name = "panel_Feature";
            panel_Feature.Size = new Size(477, 781);
            panel_Feature.TabIndex = 14;
            panel_Feature.Paint += panel_Feature_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(217, 225);
            label8.Name = "label8";
            label8.Size = new Size(88, 25);
            label8.TabIndex = 29;
            label8.Text = "Trọng số:";
            // 
            // bt_Refresh
            // 
            bt_Refresh.BackColor = SystemColors.GradientInactiveCaption;
            bt_Refresh.Cursor = Cursors.Hand;
            bt_Refresh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_Refresh.ForeColor = SystemColors.ControlDarkDark;
            bt_Refresh.Location = new Point(311, 652);
            bt_Refresh.Margin = new Padding(3, 4, 3, 4);
            bt_Refresh.Name = "bt_Refresh";
            bt_Refresh.Size = new Size(134, 44);
            bt_Refresh.TabIndex = 28;
            bt_Refresh.Text = "Đặt lại";
            bt_Refresh.UseVisualStyleBackColor = false;
            bt_Refresh.Click += bt_Refresh_Click;
            // 
            // txbTrongSo
            // 
            txbTrongSo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbTrongSo.Location = new Point(311, 217);
            txbTrongSo.Margin = new Padding(3, 4, 3, 4);
            txbTrongSo.Multiline = true;
            txbTrongSo.Name = "txbTrongSo";
            txbTrongSo.Size = new Size(119, 33);
            txbTrongSo.TabIndex = 26;
            // 
            // txb_Prim
            // 
            txb_Prim.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txb_Prim.Location = new Point(46, 516);
            txb_Prim.Margin = new Padding(3, 4, 3, 4);
            txb_Prim.Multiline = true;
            txb_Prim.Name = "txb_Prim";
            txb_Prim.Size = new Size(119, 33);
            txb_Prim.TabIndex = 24;
            // 
            // txb_DinhCuoiCuaFord
            // 
            txb_DinhCuoiCuaFord.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txb_DinhCuoiCuaFord.Location = new Point(311, 540);
            txb_DinhCuoiCuaFord.Margin = new Padding(3, 4, 3, 4);
            txb_DinhCuoiCuaFord.Multiline = true;
            txb_DinhCuoiCuaFord.Name = "txb_DinhCuoiCuaFord";
            txb_DinhCuoiCuaFord.Size = new Size(119, 33);
            txb_DinhCuoiCuaFord.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(217, 548);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 22;
            label7.Text = "Đỉnh cuối:";
            // 
            // txb_DinhDauCuaFord
            // 
            txb_DinhDauCuaFord.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txb_DinhDauCuaFord.Location = new Point(311, 497);
            txb_DinhDauCuaFord.Margin = new Padding(3, 4, 3, 4);
            txb_DinhDauCuaFord.Multiline = true;
            txb_DinhDauCuaFord.Name = "txb_DinhDauCuaFord";
            txb_DinhDauCuaFord.Size = new Size(119, 33);
            txb_DinhDauCuaFord.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(217, 505);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 20;
            label6.Text = "Đỉnh đầu:";
            // 
            // txbDinhCuoiCanXoa
            // 
            txbDinhCuoiCanXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbDinhCuoiCanXoa.Location = new Point(311, 377);
            txbDinhCuoiCanXoa.Margin = new Padding(3, 4, 3, 4);
            txbDinhCuoiCanXoa.Multiline = true;
            txbDinhCuoiCanXoa.Name = "txbDinhCuoiCanXoa";
            txbDinhCuoiCanXoa.Size = new Size(119, 33);
            txbDinhCuoiCanXoa.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(217, 385);
            label5.Name = "label5";
            label5.Size = new Size(97, 25);
            label5.TabIndex = 18;
            label5.Text = "Đỉnh cuối:";
            // 
            // txbDinhDauCanXoa
            // 
            txbDinhDauCanXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbDinhDauCanXoa.Location = new Point(311, 335);
            txbDinhDauCanXoa.Margin = new Padding(3, 4, 3, 4);
            txbDinhDauCanXoa.Multiline = true;
            txbDinhDauCanXoa.Name = "txbDinhDauCanXoa";
            txbDinhDauCanXoa.Size = new Size(119, 33);
            txbDinhDauCanXoa.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(217, 343);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 16;
            label4.Text = "Đỉnh đầu:";
            // 
            // txbDinhDau
            // 
            txbDinhDau.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbDinhDau.Location = new Point(311, 132);
            txbDinhDau.Margin = new Padding(3, 4, 3, 4);
            txbDinhDau.Multiline = true;
            txbDinhDau.Name = "txbDinhDau";
            txbDinhDau.Size = new Size(119, 33);
            txbDinhDau.TabIndex = 15;
            // 
            // bt_xoaCanh
            // 
            bt_xoaCanh.BackColor = SystemColors.GradientInactiveCaption;
            bt_xoaCanh.Cursor = Cursors.Hand;
            bt_xoaCanh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_xoaCanh.ForeColor = SystemColors.ControlDarkDark;
            bt_xoaCanh.Location = new Point(311, 420);
            bt_xoaCanh.Margin = new Padding(3, 4, 3, 4);
            bt_xoaCanh.Name = "bt_xoaCanh";
            bt_xoaCanh.Size = new Size(120, 45);
            bt_xoaCanh.TabIndex = 2;
            bt_xoaCanh.Text = "Xóa cạnh";
            bt_xoaCanh.UseVisualStyleBackColor = false;
            bt_xoaCanh.Click += bt_xoaCanh_Click;
            // 
            // txbDinhCuoi
            // 
            txbDinhCuoi.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbDinhCuoi.Location = new Point(311, 175);
            txbDinhCuoi.Margin = new Padding(3, 4, 3, 4);
            txbDinhCuoi.Multiline = true;
            txbDinhCuoi.Name = "txbDinhCuoi";
            txbDinhCuoi.Size = new Size(119, 33);
            txbDinhCuoi.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(217, 183);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 13;
            label3.Text = "Đỉnh cuối:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(217, 140);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 12;
            label2.Text = "Đỉnh đầu:";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Font = new Font("Tahoma", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(447, 103);
            label1.TabIndex = 9;
            label1.Text = "CHỨC NĂNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_xoaDinh
            // 
            bt_xoaDinh.BackColor = SystemColors.GradientInactiveCaption;
            bt_xoaDinh.Cursor = Cursors.Hand;
            bt_xoaDinh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_xoaDinh.ForeColor = SystemColors.ControlDarkDark;
            bt_xoaDinh.Location = new Point(46, 384);
            bt_xoaDinh.Margin = new Padding(3, 4, 3, 4);
            bt_xoaDinh.Name = "bt_xoaDinh";
            bt_xoaDinh.Size = new Size(120, 45);
            bt_xoaDinh.TabIndex = 7;
            bt_xoaDinh.Text = "Xóa đỉnh";
            bt_xoaDinh.UseVisualStyleBackColor = false;
            bt_xoaDinh.Click += bt_xoaDinh_Click;
            // 
            // bt_themCanh
            // 
            bt_themCanh.BackColor = SystemColors.GradientInactiveCaption;
            bt_themCanh.Cursor = Cursors.Hand;
            bt_themCanh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_themCanh.ForeColor = SystemColors.ControlDarkDark;
            bt_themCanh.Location = new Point(311, 260);
            bt_themCanh.Margin = new Padding(3, 4, 3, 4);
            bt_themCanh.Name = "bt_themCanh";
            bt_themCanh.Size = new Size(120, 41);
            bt_themCanh.TabIndex = 1;
            bt_themCanh.Text = "Thêm cạnh";
            bt_themCanh.UseVisualStyleBackColor = false;
            bt_themCanh.Click += bt_themCanh_Click;
            // 
            // txbXoaDinh
            // 
            txbXoaDinh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbXoaDinh.Location = new Point(46, 341);
            txbXoaDinh.Margin = new Padding(3, 4, 3, 4);
            txbXoaDinh.Multiline = true;
            txbXoaDinh.Name = "txbXoaDinh";
            txbXoaDinh.Size = new Size(119, 33);
            txbXoaDinh.TabIndex = 11;
            // 
            // bt_XoaDoThi
            // 
            bt_XoaDoThi.BackColor = SystemColors.GradientInactiveCaption;
            bt_XoaDoThi.Cursor = Cursors.Hand;
            bt_XoaDoThi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_XoaDoThi.ForeColor = SystemColors.ControlDarkDark;
            bt_XoaDoThi.Location = new Point(46, 716);
            bt_XoaDoThi.Margin = new Padding(3, 4, 3, 4);
            bt_XoaDoThi.Name = "bt_XoaDoThi";
            bt_XoaDoThi.Size = new Size(133, 44);
            bt_XoaDoThi.TabIndex = 6;
            bt_XoaDoThi.Text = "Xóa đồ thị";
            bt_XoaDoThi.UseVisualStyleBackColor = false;
            bt_XoaDoThi.Click += bt_XoaDoThi_Click;
            // 
            // txbThemDinh
            // 
            txbThemDinh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txbThemDinh.Location = new Point(46, 183);
            txbThemDinh.Margin = new Padding(3, 4, 3, 4);
            txbThemDinh.Multiline = true;
            txbThemDinh.Name = "txbThemDinh";
            txbThemDinh.Size = new Size(119, 33);
            txbThemDinh.TabIndex = 10;
            // 
            // bt_DocFile
            // 
            bt_DocFile.BackColor = SystemColors.GradientInactiveCaption;
            bt_DocFile.Cursor = Cursors.Hand;
            bt_DocFile.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_DocFile.ForeColor = SystemColors.ControlDarkDark;
            bt_DocFile.Location = new Point(311, 716);
            bt_DocFile.Margin = new Padding(3, 4, 3, 4);
            bt_DocFile.Name = "bt_DocFile";
            bt_DocFile.Size = new Size(134, 44);
            bt_DocFile.TabIndex = 8;
            bt_DocFile.Text = "Đọc File";
            bt_DocFile.UseVisualStyleBackColor = false;
            bt_DocFile.Click += bt_DocFile_Click;
            // 
            // bt_XetLienThong
            // 
            bt_XetLienThong.BackColor = SystemColors.GradientInactiveCaption;
            bt_XetLienThong.Cursor = Cursors.Hand;
            bt_XetLienThong.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_XetLienThong.ForeColor = SystemColors.ControlDarkDark;
            bt_XetLienThong.Location = new Point(46, 653);
            bt_XetLienThong.Margin = new Padding(3, 4, 3, 4);
            bt_XetLienThong.Name = "bt_XetLienThong";
            bt_XetLienThong.Size = new Size(133, 43);
            bt_XetLienThong.TabIndex = 3;
            bt_XetLienThong.Text = "Xét liên thông";
            bt_XetLienThong.UseVisualStyleBackColor = false;
            bt_XetLienThong.Click += bt_XetLienThong_Click;
            // 
            // bt_themDinh
            // 
            bt_themDinh.BackColor = SystemColors.GradientInactiveCaption;
            bt_themDinh.Cursor = Cursors.Hand;
            bt_themDinh.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_themDinh.ForeColor = SystemColors.ControlDarkDark;
            bt_themDinh.Location = new Point(46, 225);
            bt_themDinh.Margin = new Padding(3, 4, 3, 4);
            bt_themDinh.Name = "bt_themDinh";
            bt_themDinh.Size = new Size(120, 45);
            bt_themDinh.TabIndex = 0;
            bt_themDinh.Text = "Thêm đỉnh";
            bt_themDinh.UseVisualStyleBackColor = false;
            bt_themDinh.Click += bt_themDinh_Click;
            // 
            // bt_Prim
            // 
            bt_Prim.BackColor = SystemColors.GradientInactiveCaption;
            bt_Prim.Cursor = Cursors.Hand;
            bt_Prim.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_Prim.ForeColor = SystemColors.ControlDarkDark;
            bt_Prim.Location = new Point(46, 559);
            bt_Prim.Margin = new Padding(3, 4, 3, 4);
            bt_Prim.Name = "bt_Prim";
            bt_Prim.Size = new Size(120, 45);
            bt_Prim.TabIndex = 5;
            bt_Prim.Text = "Prim";
            bt_Prim.UseVisualStyleBackColor = false;
            bt_Prim.Click += bt_Prim_Click;
            // 
            // bt_Ford
            // 
            bt_Ford.BackColor = SystemColors.GradientInactiveCaption;
            bt_Ford.Cursor = Cursors.Hand;
            bt_Ford.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            bt_Ford.ForeColor = SystemColors.ControlDarkDark;
            bt_Ford.Location = new Point(297, 583);
            bt_Ford.Margin = new Padding(3, 4, 3, 4);
            bt_Ford.Name = "bt_Ford";
            bt_Ford.Size = new Size(152, 47);
            bt_Ford.TabIndex = 4;
            bt_Ford.Text = "Ford - Bellman";
            bt_Ford.UseVisualStyleBackColor = false;
            bt_Ford.Click += bt_Ford_Click;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1311, 828);
            Controls.Add(panel_Feature);
            Controls.Add(panel_Graph);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GraphTheory_Project";
            panel_Graph.ResumeLayout(false);
            panel_Graph.PerformLayout();
            panel_Feature.ResumeLayout(false);
            panel_Feature.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Graph;
        private Panel panel_Feature;
        private Button bt_Refresh;
        private TextBox txbTrongSo;
        private TextBox txb_Prim;
        private TextBox txb_DinhCuoiCuaFord;
        private Label label7;
        private TextBox txb_DinhDauCuaFord;
        private Label label6;
        private TextBox txbDinhCuoiCanXoa;
        private Label label5;
        private TextBox txbDinhDauCanXoa;
        private Label label4;
        private TextBox txbDinhDau;
        private Button bt_xoaCanh;
        private TextBox txbDinhCuoi;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button bt_xoaDinh;
        private Button bt_themCanh;
        private TextBox txbXoaDinh;
        private Button bt_XoaDoThi;
        private TextBox txbThemDinh;
        private Button bt_DocFile;
        private Button bt_XetLienThong;
        private Button bt_themDinh;
        private Button bt_Prim;
        private Button bt_Ford;
        private TextBox txb_KetLuan;
        private Label label8;
    }
}