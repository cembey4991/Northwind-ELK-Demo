##Northwind + PostgreSQL + Elasticsearch + Logstash + Kibana + C# API

This project sets up a PostgreSQL Northwind database, pushes its data into Elasticsearch via Logstash, and allows visualization through Kibana. A C# API project is also included to interact with the PostgreSQL database.

##🚀 Services

**PostgreSQL**

The northwind database is created automatically.

SQL scripts inside Elasticsearch.API/initdb are executed on startup to create schema and seed data.

**Elasticsearch**

Runs as a single-node cluster (discovery.type=single-node).

Stores data in a persistent esdata volume.

**Logstash**

Fetches data from PostgreSQL.

Sends data into Elasticsearch.

Config files are located in Elasticsearch.API/logstash/pipeline.

Requires the PostgreSQL JDBC driver in Elasticsearch.API/logstash/drivers.

**Kibana**

Connects to Elasticsearch.

Provides a web UI for data exploration and visualization (http://localhost:5601).

**C# API Project**

Connects to PostgreSQL to perform CRUD operations on the Northwind database.

Works seamlessly with the PostgreSQL container defined in Docker Compose.

## 📂 Project Structure

.
├── docker-compose.yml
├── Elasticsearch.API/
│ ├── initdb/ # PostgreSQL init scripts
│ └── logstash/
│ ├── pipeline/ # Logstash pipeline configs
│ └── drivers/ # PostgreSQL JDBC driver
└── src/
└── MyApi/ # C# Web API project


##🔧 Setup and Run

Clone the repository

git clone https://github.com/your-username/repository-name.git
cd repository-name


Start all services with Docker Compose

docker-compose up -d

Verify services are running

**PostgreSQL → localhost:5433

Elasticsearch → http://localhost:9200

Kibana → http://localhost:5601**

Run the C# API

Navigate to src/MyApi.

Open the project and set it as Startup Project.

Use the following connection string:

Host=localhost;Port=5433;Database=northwind;Username=postgres;Password=1

##🔗 Endpoints

PostgreSQL → localhost:5433

Elasticsearch → http://localhost:9200

Kibana → http://localhost:5601

##⚙️ Notes

PostgreSQL runs initialization scripts from Elasticsearch.API/initdb on first startup.

Logstash reads from PostgreSQL and writes to Elasticsearch using the pipeline configuration.

To explore data in Kibana, create an index pattern for the ingested data.

📌 With a single command (docker-compose up -d) you get a full data pipeline running:
PostgreSQL → Logstash → Elasticsearch → Kibana, integrated with your C# API.
