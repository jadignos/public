
namespace CourierPleaseScraper
{
    partial class MainForm
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
            this.groupTrackingNo = new System.Windows.Forms.GroupBox();
            this.txtTrackingNumbers = new System.Windows.Forms.TextBox();
            this.btnProcessNow = new System.Windows.Forms.Button();
            this.groupStatus = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTimeElapse = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupData = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.ConsignmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryETA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POPShopDropOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeadWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveredAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.References = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsCoupons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contractor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grouping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.groupTrackingNo.SuspendLayout();
            this.groupStatus.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTrackingNo
            // 
            this.groupTrackingNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupTrackingNo.Controls.Add(this.txtTrackingNumbers);
            this.groupTrackingNo.Location = new System.Drawing.Point(12, 27);
            this.groupTrackingNo.Name = "groupTrackingNo";
            this.groupTrackingNo.Size = new System.Drawing.Size(201, 445);
            this.groupTrackingNo.TabIndex = 0;
            this.groupTrackingNo.TabStop = false;
            this.groupTrackingNo.Text = "TRACKING NUMBERS";
            // 
            // txtTrackingNumbers
            // 
            this.txtTrackingNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrackingNumbers.Location = new System.Drawing.Point(3, 16);
            this.txtTrackingNumbers.MaxLength = 0;
            this.txtTrackingNumbers.Multiline = true;
            this.txtTrackingNumbers.Name = "txtTrackingNumbers";
            this.txtTrackingNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrackingNumbers.Size = new System.Drawing.Size(195, 426);
            this.txtTrackingNumbers.TabIndex = 1;
            // 
            // btnProcessNow
            // 
            this.btnProcessNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcessNow.Location = new System.Drawing.Point(12, 478);
            this.btnProcessNow.Name = "btnProcessNow";
            this.btnProcessNow.Size = new System.Drawing.Size(201, 45);
            this.btnProcessNow.TabIndex = 1;
            this.btnProcessNow.Text = "PROCESS NOW";
            this.btnProcessNow.UseVisualStyleBackColor = true;
            this.btnProcessNow.Click += new System.EventHandler(this.btnProcessNow_ClickAsync);
            // 
            // groupStatus
            // 
            this.groupStatus.Controls.Add(this.txtStatus);
            this.groupStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStatus.Location = new System.Drawing.Point(0, 0);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(695, 166);
            this.groupStatus.TabIndex = 2;
            this.groupStatus.TabStop = false;
            this.groupStatus.Text = "STATUS";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.ForeColor = System.Drawing.Color.Lime;
            this.txtStatus.Location = new System.Drawing.Point(3, 16);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(689, 147);
            this.txtStatus.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTimeElapse,
            this.progressbar});
            this.statusStrip.Location = new System.Drawing.Point(0, 537);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(926, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // lblTimeElapse
            // 
            this.lblTimeElapse.Name = "lblTimeElapse";
            this.lblTimeElapse.Size = new System.Drawing.Size(69, 17);
            this.lblTimeElapse.Text = "Time Elapse";
            // 
            // progressbar
            // 
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(100, 16);
            this.progressbar.Visible = false;
            // 
            // groupData
            // 
            this.groupData.Controls.Add(this.dataGrid);
            this.groupData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupData.Location = new System.Drawing.Point(0, 0);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(695, 325);
            this.groupData.TabIndex = 4;
            this.groupData.TabStop = false;
            this.groupData.Text = "DATA";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConsignmentNo,
            this.Date,
            this.DeliveryETA,
            this.POPShopDropOff,
            this.Details,
            this.Remarks,
            this.DeadWeight,
            this.Volume,
            this.Service,
            this.Status,
            this.DeliveredAt,
            this.POD,
            this.References,
            this.ItemsCoupons,
            this.CouponDate,
            this.Time,
            this.Contractor,
            this.ContId,
            this.Detail,
            this.Grouping});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 16);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(689, 306);
            this.dataGrid.TabIndex = 0;
            // 
            // ConsignmentNo
            // 
            this.ConsignmentNo.HeaderText = "ConsignmentNo";
            this.ConsignmentNo.Name = "ConsignmentNo";
            this.ConsignmentNo.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // DeliveryETA
            // 
            this.DeliveryETA.HeaderText = "DeliveryETA";
            this.DeliveryETA.Name = "DeliveryETA";
            this.DeliveryETA.ReadOnly = true;
            // 
            // POPShopDropOff
            // 
            this.POPShopDropOff.HeaderText = "POPShopDropOff";
            this.POPShopDropOff.Name = "POPShopDropOff";
            this.POPShopDropOff.ReadOnly = true;
            // 
            // Details
            // 
            this.Details.HeaderText = "Details";
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // DeadWeight
            // 
            this.DeadWeight.HeaderText = "DeadWeight";
            this.DeadWeight.Name = "DeadWeight";
            this.DeadWeight.ReadOnly = true;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // DeliveredAt
            // 
            this.DeliveredAt.HeaderText = "DeliveredAt";
            this.DeliveredAt.Name = "DeliveredAt";
            this.DeliveredAt.ReadOnly = true;
            // 
            // POD
            // 
            this.POD.HeaderText = "POD";
            this.POD.Name = "POD";
            this.POD.ReadOnly = true;
            // 
            // References
            // 
            this.References.HeaderText = "References";
            this.References.Name = "References";
            this.References.ReadOnly = true;
            // 
            // ItemsCoupons
            // 
            this.ItemsCoupons.HeaderText = "ItemsCoupons";
            this.ItemsCoupons.Name = "ItemsCoupons";
            this.ItemsCoupons.ReadOnly = true;
            // 
            // CouponDate
            // 
            this.CouponDate.HeaderText = "CouponDate";
            this.CouponDate.Name = "CouponDate";
            this.CouponDate.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Contractor
            // 
            this.Contractor.HeaderText = "Contractor";
            this.Contractor.Name = "Contractor";
            this.Contractor.ReadOnly = true;
            // 
            // ContId
            // 
            this.ContId.HeaderText = "ContId";
            this.ContId.Name = "ContId";
            this.ContId.ReadOnly = true;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "Detail";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // Grouping
            // 
            this.Grouping.HeaderText = "Grouping";
            this.Grouping.Name = "Grouping";
            this.Grouping.ReadOnly = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(926, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.Location = new System.Drawing.Point(219, 27);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.groupData);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.groupStatus);
            this.mainContainer.Size = new System.Drawing.Size(695, 496);
            this.mainContainer.SplitterDistance = 325;
            this.mainContainer.SplitterWidth = 5;
            this.mainContainer.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 559);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.btnProcessNow);
            this.Controls.Add(this.groupTrackingNo);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "CourierPlease Scraper";
            this.groupTrackingNo.ResumeLayout(false);
            this.groupTrackingNo.PerformLayout();
            this.groupStatus.ResumeLayout(false);
            this.groupStatus.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTrackingNo;
        private System.Windows.Forms.TextBox txtTrackingNumbers;
        private System.Windows.Forms.Button btnProcessNow;
        private System.Windows.Forms.GroupBox groupStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeElapse;        
        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsignmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryETA;
        private System.Windows.Forms.DataGridViewTextBoxColumn POPShopDropOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeadWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveredAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn POD;
        private System.Windows.Forms.DataGridViewTextBoxColumn References;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsCoupons;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contractor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grouping;
        private System.Windows.Forms.ToolStripProgressBar progressbar;
        private System.Windows.Forms.SplitContainer mainContainer;
    }
}

