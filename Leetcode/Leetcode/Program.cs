
int[] n1 = { 2, 2, 1, 1, 1, 2, 2 };
int[] n2 = { 2, 5, 6 };
int m = 3;
int n = 3;

//RemoveElement(n1, 3);

Console.WriteLine(MajorityElement(n1));

void Merge(int[] nums1, int m, int[] nums2, int n)
{
    int j = 0;
    for (int i=m; i < nums1.Length; i++)
    {
        nums1[i] = nums2[j];
        j++;
    }
    Array.Sort(nums1);
    Console.WriteLine(String.Join(' ',nums1));
}
int RemoveElement(int[] nums, int val)
{
    int res = nums.Where(x => x == val).Count();
    nums = nums.Where(x => x != val).ToArray();
    return res;
}

int MajorityElement(int[] nums)
{
    int count = 0;
    int elem = 0;
    for(int i=0; i < nums.Length; i++)
    {
        if (count == 0)
        {
            elem = nums[i];
            count++;
        }
        else
        {
            if (elem == nums[i])
            {
                count++;
            }
            else
            {
                count--;
            }
        }
    }
    return elem;
}