
abstract class Skill{

    public mounter parent;

    public string name = "";
}

public abstract class ActiveSkill:Skill{

    protected abstract bool doFire();

    public bool Fire(){
        return doFire();
    }

}

public class PassiveSkill:Skill{

    
}


