public interface ITower
{
    public string TowerName { get; set; }
    public int Price { get; set; }
    public decimal Range { get; set; }
    public decimal ShottingSpeed { get; set; }
    public int TowerLevel { get; set; }
    public void Initialize();
}
