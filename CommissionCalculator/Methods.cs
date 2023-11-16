public class Methods
{
  public int Total { get; set; }
  public void Add(int value)
  {
    Total += value;
  }
  public void Reset()
  {
    Total = 0;
  }
}