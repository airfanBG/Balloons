﻿// See https://aka.ms/new-console-template for more information
using Balloons.Configuration;
using Balloons.Interfaces;
using Ninject;

Console.WriteLine("Hello, World!");
IKernel kernel = new StandardKernel(new DependencyConfig());

try
{
    IEngine engine = kernel.Get<IEngine>();
    engine.Run();

}
catch (Exception e)
{

	throw e;
}


public abstract class Animal
{
    public string AnimalName { get; set; }
    public int Legs { get; set; }
}
public class Cat : Animal
{
}
public class Snake : Animal
{

}