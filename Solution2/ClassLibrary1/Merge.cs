using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Merge
    {
        public void MyMerge(int[] arr1, int[] arr2, int[] mergedArray)
        {
            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    mergedArray[k] = arr1[i];
                    i++;
                }
                else
                {
                    mergedArray[k] = arr2[j];
                    j++;
                }
                k++;
            }
            while (i < arr1.Length)
            {
                mergedArray[k] = arr1[i];
                i++;
                k++;
            }
            while (j < arr2.Length)
            {
                mergedArray[k] = arr2[j];
                j++;
                k++;
            }
        }
    }
}
