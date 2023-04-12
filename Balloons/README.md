Simple balloons game. At the beginning we add some balloons and arrows from the console as command. See sample input. Only same color arrow must strike same color balloons. Each arrow has an accurancy ant total attempts. When arrow is thrown its counter increases until became an equal of its accurancy. Then gameplay consider this throw as missed and balloon remains whole. The game continuous until all balloons are bursted. 

```
input

createballoon red
createarrow red 3
throw red

```

## Technologies
**[Ninject](http://www.ninject.org)**</br>
**[Ninject Factory](https://github.com/ninject/Ninject.Extensions.Factory)**

## Architecture
Simple DDD architecture in console application. This game is just for students training purpouse