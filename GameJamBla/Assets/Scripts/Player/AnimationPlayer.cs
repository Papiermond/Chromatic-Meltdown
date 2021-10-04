using UnityEngine;

public class AnimationPlayer : MonoBehaviour{
public Animator animator;

public void Animate(bool Attack,bool Jump,float Speed){ 



    animator.SetFloat("Speed",Speed);
    animator.SetBool("Attack",Attack);
    animator.SetBool("Jumped",Jump);



}




}