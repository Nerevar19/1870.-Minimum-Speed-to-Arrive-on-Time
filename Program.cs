namespace _1870._Minimum_Speed_to_Arrive_on_Time
{
    internal class Program
    {
        static public double CalculateTimeWithSpeed(int[] dist,int speed)
        {
            double time = 0;
            for(int i = 0; i < dist.Length - 1; i++)
            {
                time += Math.Ceiling(Convert.ToDouble(dist[i]) / Convert.ToDouble(speed));
            }
            time += Convert.ToDouble(dist[dist.Length - 1]) / Convert.ToDouble(speed);
            return time;
        }
       

        static public int MinSpeedOnTime(int[] dist, double hour)
        {

            if (Convert.ToDouble(dist.Length) - hour >= 1) return -1;
            // S = v * t; v = S / t ; t = S / V
            int lower = 1, upper = 10000000;
            int midSpeed = (lower + upper) / 2;

            while(upper - lower > 1)
            {
                if (CalculateTimeWithSpeed(dist, midSpeed) <= hour) upper = midSpeed;
             
                else if (CalculateTimeWithSpeed(dist, midSpeed) > hour) lower = midSpeed;
               
                midSpeed = (lower + upper) / 2;
            }
            if (CalculateTimeWithSpeed(dist, lower) <= hour) return lower;
            else return upper;

        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[100000];
            int[] dist = { 1, 3, 7 };
            for(int i = 0; i < array.Length ; i++)
            {
                array[i] = rand.Next(100000);
            }
            Console.WriteLine(MinSpeedOnTime(array,1000000));
           // Console.WriteLine(Math.Floor(2.6)+1);
            //Console.WriteLine(CalculateTimeWithSpeed(dist, 10000));
        }
    }
}