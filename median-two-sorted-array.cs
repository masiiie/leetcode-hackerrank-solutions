using System;
					
public class Program
{
	public static void Main()
	{
        // 1 1 1 2 2 2 3 6 7 
        /*
        int[] nums1 = new int[3]{1,1,2,3};
        int[] nums2 = new int[4]{1,2,2,6,7};
        ok

        int[] nums1 = new int[3]{1,2,3};
        int[] nums2 = new int[4]{4,5,6,7};
        ok

        int[] nums1 = new int[1]{2};
        int[] nums2 = new int[2]{1,3};
        Console.WriteLine(sol.FindMedianSortedArrays(nums1, nums2));
        ok

        int[] nums1 = new int[1]{2};
        int[] nums2 = new int[2]{1,3};
        Console.WriteLine(sol.FindMedianSortedArrays(nums2, nums1));
        ok

        
        */
		Solution sol = new Solution();
        int[] nums1 = new int[3]{1,2,3};
        int[] nums2 = new int[4]{4,5,6,7};

        Console.WriteLine(sol.FindMedianSortedArrays(nums1,nums2));
	}
}

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        return FindMedianSortedArrays(nums1, nums2, 0, nums1.Length-1, 0, nums2.Length-1);
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2, int i11, int i12, int i21, int i22){
        /*
            Casos base: los i11>i12
            indices negativos o indices mayores q el length del array
        */ 
        int pos1 = i11 + i12;
        int pos2 = i21 + i22;

        int median1pos = pos1%2==0 ? pos1/2 : (pos1-1)/2;
        int median2pos = pos2%2==0 ? pos2/2 : (pos2-1)/2; 

        int median1 = nums1[median1pos];
        int median2 = nums2[median2pos];

        if(i11==i12 && i21==i22) return Math.Min(nums1[i11],nums2[i21]);
        else if(i11!=i12 && i21==i22){
            if(pos1%2 != 0){
                if(median2<=median1) return median1;
                else return Math.Min(nums1[median1pos+1], median2);
            }
            else if(median2<=median1) return (median1 + Math.Max(nums1[median1pos-1], median2))/2;
            else return (median1 + Math.Min(nums1[median1pos+1], median2))/2;
        }
        else if(i11==i12 && i21!=i22){
            if(pos2%2 != 0){
                if(median1<=median2) return median2;
                else return Math.Min(nums2[median2pos+1], median1);
            }
            else if(median1<=median2) return (median2 + Math.Max(nums2[median2pos-1], median1))/2;
            else return (median2 + Math.Min(nums2[median2pos+1], median1))/2;
        }
        else{
            if(median1==median2){
                if(pos1%2 != 0 && pos2%2 != 0){
                    int next1 = nums1[median1pos+1];
                    int next2 = nums2[median2pos+1];

                    if(next1<=next2) return (median1+next1)/2;
                    else return (median1+next2)/2;
                }
                else return median1;
            }
            else if(median1<median2){
                int stepsAdded = (median1pos-i11)+1;
                return FindMedianSortedArrays(nums1, nums2, median1pos+1, i12, Math.Max(i21-stepsAdded, 0), Math.Max(i22-stepsAdded, 0));
            }
            else{
                int stepsAdded = (median2pos-i21)+1;
                return FindMedianSortedArrays(nums1, nums2, Math.Max(i11-stepsAdded, 0), Math.Max(i12-stepsAdded, 0), median2pos+1, i22);
            }
        }
    }
}

/*
if(pos1%2 == 0 && pos2%2 == 0) return median1;
else if(pos1%2 != 0 && pos2%2 != 0){
    int next1 = nums1[(pos1+1)/2];
    int next2 = nums2[(pos2+1)/2];

    if(next1==next2) return (median1+next1)/2;
    else if(next1<next2) return (median1+next1)/2;
    else return (median1+next2)/2;
}
else if(pos1%2 != 0 && pos2%2 == 0) return median2;
else return median1; // if(pos1%2 == 0 && pos2%2 != 0)
*/