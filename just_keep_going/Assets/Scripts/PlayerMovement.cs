using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    public float moveSpeed = 25f;
    public float acceleration = 800f;
    public float decceleration = 1000f;
    public float velPower = 0.95f;

    public float jumpForce = 10f;
    public float fallGravityMultiplier = 2f;

    public float dashForce = 50f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private float horizontalMove;
    private int jumpCounter = 0;
    private bool grounded = true;
    private float gravityScale;
    private float nextDashTime;
    private bool isFacingRight = true;

    void Start(){
        rb = GetComponent<Rigidbody2D>(); //Der Rigidbody der dem Spieler zugeordnet ist
        gravityScale = rb.gravityScale; //Die Variable gravityScale wird der normalen Anziehungskraft des rigidbodys gleichgesetzt
        
    }

    void MoveSideways(){
        float targetSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed; // 1 bzw -1 * moveSpeed der in der Engine mittels Eingabe bestimmt wird
        float speedDiff = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration; // Wenn der Knopf zum bewegen gedrückt ist ist accelRate = acceleration, sonst decceleration
        horizontalMove = Mathf.Pow(Mathf.Abs(speedDiff) * accelRate, velPower) * Mathf.Sign(speedDiff); 
        rb.AddForce(horizontalMove * Vector2.right * Time.deltaTime, 0);
        Flip();
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }

    void Flip(){
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            isFacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isFacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && jumpCounter <= 1){ 
            jumpCounter++;
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            if (rb.velocity.y < 0){ //da die anziehungskraft beim nach unten fliegen höher ist, müssen wir die jumpForce erhöhen um dagegenzuwirken
                rb.AddForce(new Vector2(0, jumpForce * Mathf.Abs(rb.velocity.y/15)), ForceMode2D.Impulse);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else{
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);//Es wird eine Kraft in Höhe von jumpForce an den rigidBody übergeben
            }
            grounded = false;
        }

        if(rb.velocity.y < 0){
           // rb.gravityScale = gravityScale * fallGravityMultiplier; // Dadurch fühlt sich das spiel nicht so "floaty" an, beim hinunterfliegen wird die schwerkraft erhöht
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            anim.SetFloat("yVelocity", -1);
        }
        else if(rb.velocity.y > 0){
            rb.gravityScale = gravityScale; //Wenn der spieler nicht nach unten fliegt, wird die Anziehungskraft des rigidbody wieder auf die normale gravityscale zurückgesetzt
            anim.SetFloat("yVelocity", 1);
        }
        else{
            anim.SetFloat("yVelocity", 0);
        }

        if(grounded){
            jumpCounter = 0;
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
        }
    }

    void Dash(){
        if(Input.GetButtonDown("Fire1") && nextDashTime <= Time.time){
            anim.ResetTrigger("Roll");
            anim.SetTrigger("Roll");
            rb.AddForce(dashForce * Input.GetAxisRaw("Horizontal") * Vector2.right);
           nextDashTime = Time.time + dashCooldown;
        }
    }

    void Attack(){
        if (Input.GetMouseButtonDown(0)){
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Attack");
        }
    }

    void OnTriggerEnter2D(Collider2D collision){ //der Trigger ist ein kleines Feld unterhalb des Spielers, wenn dieser mit Ground kollidiert wird grounded auf true gesetzt
        if(collision.gameObject.tag == "Ground"){ //in der Engine hat der Boden den Tag "Ground"
            grounded = true;
        }
    }

    

    void Update(){

       MoveSideways();
       Jump();
       Dash();
       Attack();

    }

    
}
