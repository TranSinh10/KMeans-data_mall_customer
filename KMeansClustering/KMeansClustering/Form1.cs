using System.Data;
using System.Diagnostics.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace KMeansClustering
{
    public partial class Form1 : Form
    {
        private DataTable customerTable;
        private List<Customer> customers;
        private List<Cluster> clusterList;
        public Form1()
        {
            InitializeComponent();
            numClustersTextBox.Text = "3";
        }
        public class Customer
        {
            public int Id { get; set; }
            public int Gender { get; set; }
            public int Age { get; set; }
            public int Income { get; set; }
            public int Spending { get; set; }
            public Cluster Cluster { get; set; }
        }

        public class Cluster
        {
            public Customer Centroid { get; set; }
            public List<Customer> Customers { get; set; }

            public Cluster()
            {
                Customers = new List<Customer>();
            }
        }
        private List<Customer> LoadDataFromCsv(string filename)
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    // Tạo đối tượng Customer từ các giá trị đọc được
                    Customer customer = new Customer
                    {
                        Id = int.Parse(values[0]),
                        Gender = int.Parse(values[1]),
                        Age = int.Parse(values[2]),
                        Income = int.Parse(values[3]),
                        Spending = int.Parse(values[4])
                    };

                    // Thêm khách hàng vào danh sách
                    customers.Add(customer);
                }
            }

            return customers;
        }
        private void DisplayData(List<Customer> customers, DataGridView dataGridView1)
        {
            dataGridView1.DataSource = customers;
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            string filePath = "E:\\Đồ án tốt nghiệp\\Dữ liệu\\Mall_Customer.csv";
            customers = LoadDataFromCsv(filePath);
            DisplayData(customers, dataGridView1);
        }
        private double GetEuclideanDistance(Customer customer, Customer centroid)
        {
            double distance = 0;
            distance += Math.Pow(customer.Income - centroid.Income, 2);
            distance += Math.Pow(customer.Spending - centroid.Spending, 2);
            return Math.Sqrt(distance);
        }
        private void clusterButton_Click(object sender, EventArgs e)
        {
            if (customers == null)
            {
                MessageBox.Show("Please load data first.");
                return;
            }
            int k = int.Parse(numClustersTextBox.Text);


            // Khởi tạo K centroid ngẫu nhiên
            clusterList = new List<Cluster>();
            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                int index = rand.Next(customers.Count);
                Cluster cluster = new Cluster { Centroid = customers[index] };
                clusterList.Add(cluster);
            }

            // Thực hiện phân cụm K-Means
            bool isClusterChanged = true;
            int iteration = 0;
            while (isClusterChanged && iteration < 1000)
            {
                isClusterChanged = false;
                iteration++;

                // Gán mỗi dòng dữ liệu vào cụm gần nhất
                foreach (Customer customer in customers)
                {
                    double minDistance = double.MaxValue;
                    Cluster nearestCluster = null;
                    foreach (Cluster cluster in clusterList)
                    {
                        double distance = GetEuclideanDistance(customer, cluster.Centroid);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestCluster = cluster;
                        }
                    }
                    if (nearestCluster != customer.Cluster)
                    {
                        isClusterChanged = true;
                        customer.Cluster?.Customers.Remove(customer);
                        nearestCluster.Customers.Add(customer);
                        customer.Cluster = nearestCluster;
                    }
                }

                // Cập nhật vị trí centroid
                foreach (Cluster cluster in clusterList)
                {
                    if (cluster.Customers.Any())
                    {
                        double sumAge = cluster.Customers.Sum(c => c.Age);
                        double sumIncome = cluster.Customers.Sum(c => c.Income);
                        double sumSpending = cluster.Customers.Sum(c => c.Spending);
                        int count = cluster.Customers.Count;
                        Customer newCentroid = new Customer
                        {
                            Id = cluster.Centroid.Id,
                            Gender = cluster.Centroid.Gender,
                            Age = cluster.Centroid.Gender,
                            Income = (int)Math.Round(sumIncome / count),
                            Spending = (int)Math.Round(sumSpending / count)
                        };
                        cluster.Centroid = newCentroid;
                    }
                }
            }
            // Hiển thị kết quả phân cụm lên biểu đồ
            PlotModel plotModel = new PlotModel();
            CategoryAxis xAxis = new CategoryAxis { Position = AxisPosition.Bottom };
            LinearAxis yAxis = new LinearAxis { Position = AxisPosition.Left };
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            for (int i = 0; i < clusterList.Count; i++)
            {
                ScatterSeries series = new ScatterSeries { Title = $"Cluster {i + 1}" };
                foreach (Customer customer in clusterList[i].Customers)
                {
                    series.Points.Add(new ScatterPoint(customer.Income, customer.Spending, 3));
                }
                plotModel.Series.Add(series);
            }
            for (int i = 0; i < clusterList.Count; i++)
            {
                Cluster cluster = clusterList[i];
                ScatterSeries centroidSeries = new ScatterSeries { Title = $"Centroid {i + 1}" };
                centroidSeries.MarkerFill = OxyColor.FromRgb(0, 100, 100);
                centroidSeries.Points.Add(new ScatterPoint(cluster.Centroid.Income, cluster.Centroid.Spending, 5));
                plotModel.Series.Add(centroidSeries);
            }

            plotView1.Model = plotModel;
        }
    }
}