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
├── web/social-media/   # Frontend built with React (NextJs)
├── docker-compose.yml  # Docker configuration file
└── README.md           # Documentation
</pre>


## Critique

One of the key aspects missing in this project is unit testing on the frontend. Unit tests are crucial for validating individual components and ensuring that business logic works as expected. Without them, the risk of regressions increases, making the application harder to maintain and scale as new features are added.

Additionally, if I had more time, I would implement end-to-end (E2E) tests for the frontend. E2E tests provide a higher level of confidence in the application’s functionality by simulating real user interactions across different workflows. This would help detect potential integration issues between the frontend and backend, ensuring a more stable and reliable system.

From a scalability perspective, the current setup could be improved by implementing a Kubernetes cluster for horizontal scaling. Right now, the project relies on Docker Compose, which is ideal for local development and small-scale deployments. However, for a production-grade environment handling increased traffic and load, transitioning to Kubernetes would offer:

Automatic scaling based on resource usage.
Better load balancing to distribute requests efficiently.
Self-healing capabilities, where failed containers are restarted automatically.
Improved deployment strategies, such as rolling updates and blue-green deployments.
By incorporating unit tests, E2E tests, and a Kubernetes-based infrastructure, the project would benefit from:

Higher reliability through automated testing and reduced risk of regressions.
Improved scalability by efficiently handling increased workloads.
Better maintainability with a structured CI/CD pipeline ensuring smooth deployments.
Implementing these improvements would make the system more robust, scalable, and production-ready, allowing it to support a growing number of users with minimal downtime and operational overhead.