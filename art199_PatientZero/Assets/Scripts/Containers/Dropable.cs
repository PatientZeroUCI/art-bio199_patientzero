
// An interface for objects that can take liquids from a pipette
public interface Dropable {
    // Returns true if it can take the liquid
    bool TakeLiquid(Liquid liquid);
}
