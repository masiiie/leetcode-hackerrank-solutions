class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int medium = numbers.Length/2;
        int final = target<=numbers[medium] ? medium+1 : numbers.Length;

        for(int i=0;i<final;i++){
            for(int j=i+1;j<final;j++){
                if(numbers[i]+numbers[j]==target) return new int[2]{i+1,j+1};
            }
        }
        return new int[2]{0,1};
    }
}

class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int medium = numbers.Length/2;
        int final = target<=numbers[medium] ? medium+1 : numbers.Length;

        int i=0;
        int j=numbers.Length-1;

        while(i<j){
            int suma = numbers[i]+numbers[j];
            if(suma==target) break;
            else if(suma>target) j--;
            else i++;
        }
        return new int[2]{i+1,j+1};
    }
}