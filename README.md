# Memory tests example
This repository contains a set of unit tests that verify the behavior of value types and reference types, as well as demonstrate the throwing of the `OutOfMemoryException` when the system reaches its memory limit.
The tests are executed within a Docker container that has been configured with a 4GB memory limit.

## Status
![Unit tests in Docker](https://github.com/nogov/memory-tests-lab/actions/workflows/docker-tests.yml/badge.svg)

## Running the code locally

Requirements:
- Docker

```bash
git clone <repo-url> <repo-folder>
cd <repo-folder>
sudo chmod +x ./run.sh ; sudo ./run.sh
```

After the tests finish running, you can view the test results in the console output.

Note: this script will remove any existing containers with the same image, rebuild the image from the Dockerfile, create a new container, and start it. The tests will run inside the container.
