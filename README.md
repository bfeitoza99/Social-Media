# Social Media

This project simulates a social media using a backend built with .NET 8 and a frontend built with Angular.

## 🔗 How to Run the Project

### Using Docker

#### Prerequisites
- Ensure **Docker** is installed and running on your machine.

#### Steps
1. Navigate to the root directory of the project where the `docker-compose.yml` file is located.
2. Run the following command in your terminal:
   ```sh
   docker-compose up -d
3. After the services are up, access the application:

- **Frontend**: [http://localhost:3000](http://localhost:3000)
- **Backend API**: [http://localhost:8001](http://localhost:8001)


## Project Structure
<pre>
socialMedia/
│
├── server/SocialMedia/ # Backend API built with .NET 8
├── web/social-media/   # Frontend built with Angular
├── docker-compose.yml  # Docker configuration file
└── README.md           # Documentation
</pre>
