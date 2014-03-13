/*
 * Created by SharpDevelop.
 * User: Apple
 * Date: 3/13/2014
 * Time: 2:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
namespace CoinChange
{
	class Program
	{
		public static LinkedList<ArrayList> notesAll=new LinkedList<ArrayList>();
		public static int coinChangeRec(int sum, int[] coins,int start,ArrayList notes){
			
			if(start>=coins.Length || sum<0){
				return 0;
			}
			if(sum==0){

				notesAll.AddLast((ArrayList)notes.Clone());
				return 1;
			}
			
			int noFirst=coinChangeRec(sum, coins,start+1,notes);
	
			
			
		
			notes.Add(coins[start]);
			int withFirst=coinChangeRec(sum-coins[start],coins, start,notes);
			notes.RemoveAt(notes.Count-1);
		
			
			return noFirst+withFirst;
			
			
		}
		
		public static int coinChangeDP(int sum, int []coins){
			
			int n=coins.Length;
			
			int [,]L=new int[n+1,sum+1];
			for(int i=0;i<n+1;i++){
				L[i,0]=1;
			}
			for(int j=1;j<sum+1;j++){
				L[0,j]=0;
			}
			for(int i=1;i<n+1;i++){
				for(int j=1;j<sum+1;j++){
					int withFirst=0;
					if(j>=coins[i-1]){
						withFirst=L[i,j-coins[i-1]];
					}
					L[i,j]=withFirst+L[i-1,j];
				}
			}
			ArrayList paths=new ArrayList();
			Console.WriteLine(sum+" "+coins+" "+(coins.Length-1));
			printPaths(L,sum, coins,coins.Length-1,paths);
			return L[n,sum];
		}
		public static void printPaths(int[,] L, int sum, int []coins, int end,ArrayList paths){
			
			if(sum==0){
				foreach(int i in paths){
					Console.Write(i+" ");
				}
				Console.WriteLine();
				return;
			}
			if(sum<0 || end<0){
		
				return;
			}
			
			if(sum-coins[end]>=0 && L[end,sum-coins[end]]>=0){
	
				paths.Add(coins[end]);
				printPaths(L,sum-coins[end],coins,end,paths);
				paths.RemoveAt(paths.Count-1);
				
			}
			printPaths(L,sum,coins,end-1,paths);
			return;
			
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			int []coins={1,2,5,10};
			int sum=5;
			ArrayList notes=new ArrayList();
			Console.WriteLine(coinChangeRec(sum, coins,0,notes));
			foreach(ArrayList x in notesAll){
				
				foreach(int y in x)
					Console.Write(y+" ");
				Console.WriteLine();
			}
			Console.WriteLine(coinChangeDP(sum,coins));
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}