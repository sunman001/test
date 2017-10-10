using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dba
{
    /// <summary>
    /// 泛型实际上是语法糖，有编译器提供的功能
    /// 泛型方法在调用的时候会生成对应的副本
    /// 泛型无处不在 可以有泛型方法、类、接口、委托
    /// </summary>
  public   class Common
    {
     
        
        /// <summary>
        /// 通过继承，子类拥有父类的一切行为和属性，任何父类出现的地方子类都可以代替
        /// object是所有类型的父类
        /// 有性能损失（重复的装箱和拆装）
        /// </summary>
        /// <param name="oparameter">可以传入各种类型（datetime/int/string/class） 此方法
        /// </param>
        public static void ShowObject(object oparameter)
        {
            Console.WriteLine("这里是Common.ShowObject,parameter={0},paramtertype={1}",oparameter,oparameter.GetType());
        }

        /// <summary>
        /// 泛型方法（不同类型的方法传入到一个参数中）
        /// 方法声明的时候没有指定参数类型，而是推迟到使用的方法的时候才指定参数类型
        /// 延迟思想
        /// 泛型参数的个数是随便定义的
        /// 没有性能损失 没有装箱和拆装
        /// </summary>
        /// <typeparam name="T">T是个类型参数<占位符></typeparam>
        /// <param name="tparameter"></param>
       public static void ShowT<T>(T tparameter)
        {
           // tparameter.GetHashCode 只有四个方法 基于Object方法
            Console.WriteLine("这里是泛型方法，parmeter={},paramtertype={}",tparameter,tparameter.GetType());
        }
        /// <summary>
        /// 1、泛型约束声明后，类型参数必须满足约束
        /// 引用类型的默认值 return null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Getclass<T>(T t)
            where T:class ,new()//约束， class :是一个引用类型  new :无参的构造函数
        {
            return default(T);
        }

        public static T Getint<T>(T t)
            where T:struct//是一个值类型
        {
            return default(T);
        }
        public static void SayHi<T>(T t) where T:CoAgent//t必须是CoAgent 类型或者是CoAgent的子类
        {
            List<CoAgent> list = new  List<CoAgent>();

            Console.WriteLine(t.Name);
        }
       
        public interface ISaySomething
        {
            void sayHello();
        }
       /// <summary>
       /// 泛型方法之泛型返回
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="id"></param>
       /// <param name="t"></param>
       /// <returns></returns>
        public static T Get<T>(int id,T t)
        {
            return default(T);//会根据T的类型产生一个默认值
        }

        public class SomeGenericClass<W,S,T,TI>//泛型类
        {

        }

        public interface GenericInterface<T,S,s>//泛型接口
        {

        }
        public delegate T GetDelegate<T>();//泛型委托
    }
}
