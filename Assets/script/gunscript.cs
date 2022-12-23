using UnityEngine;

public class gunscript : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;
    public float damage = 100f;
    public Target target;
    public ParticleSystem gunHitFlash;
    public ParticleSystem hitEffectWall, bearhitEffect;
    public AudioSource fireSound;
    
    public Animator charAnimator, bearAnimator;
    //public int bearHealth = 100;
    public LayerMask layer;
    //public GameObject bear;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shooting();
            fireSound.Play();

        }
        else
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red);
            charAnimator.SetBool("isShoot", false);
        }
        //Debug.Log(bearHealth);
    }

    void shooting()
    {
        gunHitFlash.Emit(1);
        charAnimator.SetBool("isShoot", true);
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layer))
        {
            bearhitEffect.transform.position = hit.point;
            bearhitEffect.transform.forward = hit.normal;
            bearhitEffect.Emit(1);  
            target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.getHit(35);
                //hit.transform.GetComponent<BearMovement>().isAlive = false;
            }
        }else if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            hitEffectWall.transform.position = hit.point;
            hitEffectWall.transform.forward = hit.normal;
            hitEffectWall.Emit(3);
        }
    }
}
