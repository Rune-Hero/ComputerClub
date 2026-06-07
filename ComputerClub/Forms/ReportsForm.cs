using ComputerClub.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerClub.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly SessionService _sessionService;
        private Chart lineChart;
        private Chart pieChart;

        public ReportsForm()
        {
            InitializeComponent();
            _sessionService = new SessionService();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            this.Load += ReportsForm_Load;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            InitializeCharts();
            SetupPeriodComboBox();
        }

        private void InitializeCharts()
        {
            lineChart = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            ChartArea lineArea = new ChartArea("LineArea") { BackColor = Color.White };
            lineChart.ChartAreas.Add(lineArea);
            panelLineChart.Controls.Add(lineChart);

            pieChart = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            ChartArea pieArea = new ChartArea("PieArea");
            pieChart.ChartAreas.Add(pieArea);

            Legend pieLegend = new Legend("PieLegend") { Docking = Docking.Right };
            pieChart.Legends.Add(pieLegend);
            panelPieChart.Controls.Add(pieChart);
        }

        private void SetupPeriodComboBox()
        {
            cbPeriod.Items.Clear();
            cbPeriod.Items.AddRange(new string[] { "За сьогодні", "За останні 7 днів", "За останні 30 днів" });

            cbPeriod.SelectedIndexChanged += CbPeriod_SelectedIndexChanged;
            cbPeriod.SelectedIndex = 2;
        }

        private void CbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;

            switch (cbPeriod.SelectedIndex)
            {
                case 0:
                    startDate = DateTime.Today;
                    break;
                case 1:
                    startDate = DateTime.Today.AddDays(-7);
                    break;
                case 2:
                    startDate = DateTime.Today.AddDays(-30);
                    break;
            }

            UpdateDashboardData(startDate, endDate);
        }

        private void UpdateDashboardData(DateTime start, DateTime end)
        {
            DataRow kpiRow = _sessionService.GetSummaryKPI(start, end);
            if (kpiRow != null)
            {
                lblTotalRevenue.Text = $"{Convert.ToDecimal(kpiRow["TotalRevenue"]):N2} грн";
                lblTotalSessions.Text = kpiRow["TotalSessions"]?.ToString();
                lblTotalHours.Text = $"{kpiRow["TotalHours"]} год.";
            }

            lineChart.Series.Clear();

            Series lineSeries = new Series("RevenueSeries")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.DodgerBlue,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                IsValueShownAsLabel = true
            };

            bool isToday = (start.Date == end.Date);
            DataTable revenueData;
            var area = lineChart.ChartAreas[0];

            if (isToday)
            {
                lineSeries.XValueType = ChartValueType.Int32;
                revenueData = _sessionService.GetRevenueByHours(start);

                foreach (DataRow row in revenueData.Rows)
                {
                    int hour = Convert.ToInt32(row["SessionHour"]);
                    double revenue = Convert.ToDouble(row["HourlyRevenue"]);
                    lineSeries.Points.AddXY(hour, revenue);
                }

                area.AxisX.Minimum = 0;
                area.AxisX.Maximum = 23;
                area.AxisX.Interval = 1;
                area.AxisX.IntervalType = DateTimeIntervalType.Number;

                area.AxisX.LabelStyle.Format = "";
                area.AxisX.Title = "Година";

                area.RecalculateAxesScale();
            }
            else
            {
                lineSeries.XValueType = ChartValueType.DateTime;
                revenueData = _sessionService.GetRevenueByDays(start, end);

                foreach (DataRow row in revenueData.Rows)
                {
                    DateTime sessionDate = Convert.ToDateTime(row["SessionDate"]);
                    double revenue = Convert.ToDouble(row["DailyRevenue"]);
                    lineSeries.Points.AddXY(sessionDate.Date, revenue);
                }

                area.AxisX.Minimum = start.Date.ToOADate();
                area.AxisX.Maximum = end.Date.ToOADate();
                area.AxisX.IntervalType = DateTimeIntervalType.Days;
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Format = "dd.MM";
                area.AxisX.Title = "Дата";

                area.RecalculateAxesScale();
            }

            lineChart.Series.Add(lineSeries);
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            pieChart.Series.Clear();

            Series pieSeries = new Series("TariffSeries")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            DataTable tariffData = _sessionService.GetTariffPopularity(start, end);

            foreach (DataRow row in tariffData.Rows)
            {
                string tariffName = row["TariffName"]?.ToString() ?? "Інше";
                int count = Convert.ToInt32(row["UsageCount"]);

                int pointIndex = pieSeries.Points.AddXY(tariffName, count);
                pieSeries.Points[pointIndex].LegendText = tariffName;
            }

            pieChart.Series.Add(pieSeries);
            pieChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}