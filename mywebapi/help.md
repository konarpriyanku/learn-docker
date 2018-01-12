Build and run the Docker image
---------------------------------------

    In the command prompt and navigate to your project folder.
    Use the following commands to build and run your Docker image:

$ docker build -t myapp .
$ docker run -d -p 3000:80 --name myapp mywebapi

Scale the app
-------------------------------------------------

In order to scale our app we first need to enable Docker Swarm mode; do this by running docker swarm init in PowerShell.

Now that Docker Swarm mode is enabled, we will create a task for the swarm and start our app as a service. The service command is similar to the docker run command. You should name your service the same way we named our container earlier, so it's easy to target the service using scale.

Create and start our new tokengen service on Docker Swarm:

docker service create --publish 3000:80 --name mywebapi myapp

Now if we run docker service ls, we can check if our service is running

It's time to scale our app. The scale command lets us run replicas of our application.


Running docker ps will show 3 tokengen containers:
----------------------------------------------------------
docker service scale tokengen=3

docker ps

As you can see the load balancer distributes our calls to all 3 replicas. Docker Swarm uses a round-robin system to load balance between the containers.

We can also scale down our service or even stop it by scaling to 0:

docker service scale myapp=0

We can remove the service in the same way we deleted the container (using rm):

docker service rm  myapp