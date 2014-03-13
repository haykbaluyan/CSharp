/*
 * Created by SharpDevelop.
 * User: Apple
 * Date: 3/13/2014
 * Time: 4:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Knapsack
{
	class Program
	{
		//take maximum value, not exceeding W total weight
		public static int knapsack(int []weights, int []values, int W){
			
			int nW=weights.Length;
			int [,]L=new int[nW+1,W+1];
			char [,]track=new char[nW+1,W+1];
			for(int i=0;i<nW+1;i++){
				L[i,0]=0;
			}
			for(int j=0;j<W+1;j++){
				L[0,j]=0;
			}
			for(int i=1;i<nW+1;i++){
				for(int j=1;j<W+1;j++){
					int withI=0;
					if(j>=weights[i-1]){
						withI=L[i-1,j-weights[i-1]]+values[i-1];
					}
					int noI=L[i-1,j];
					if(withI>noI){
						track[i,j]='W';
						L[i,j]=withI;
					}
					else
					{
						track[i,j]='N';
						L[i,j]=noI;
					}
				
				}
			}
			
			int row=nW;
			int col=W;
			//print tracking matrix
			/*for(row=0;row<nW+1;row++){
				for(col=0;col<W+1;col++){
					Console.Write(track[row,col]+" ");
				}
				Console.WriteLine();
			}*/
			row=nW;
			col=W;
			//print the solution (chosen weights)
			//at most nW time (r-- in each loop)
			while(row>0 && col>0){
			
				if(track[row,col]=='W'){
					
					Console.WriteLine(weights[row-1]+" "+values[row-1]);
					
					col=col-weights[row-1];
			
					
				}
				
				row--;
				
			}
			return L[nW,W];
			
			
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			int []val = {60, 100, 120};
			int []wt = {1, 2,3};
			int W=5;
			Console.WriteLine(knapsack(wt,val,W));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}