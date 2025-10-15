# Setup Throwable Objects - Instrucțiuni SIMPLE

## ✅ Ce am creat:

### 1. **Throwable.cs** - Script pentru mingi
- Configurează setările de throw pentru mingile tale
- Detectează coliziuni cu pisici/baloane
- **NU adaugă componente automat - folosește ce ai setat tu deja!**

### 2. **Balloon.cs** - Script pentru pisici/baloane plutitoare
- **Plutesc în aer** (nu cad jos!)
- **Bobbing effect** - mișcare lentă sus-jos
- Explodează când sunt lovite de mingi
- Sistem de puncte

### 3. **GameManager.cs** - Tracking scor (opțional)
- Numără scorul
- Afișare UI

---

## 🚀 Pași RAPIZI pentru configurare:

### PASUL 1: Adaugă XR Direct Interactor pe controllere (OBLIGATORIU!)

**Fără asta NU poți apuca obiecte!**

1. Deschide scena ta în Unity
2. În Hierarchy, găsește: `XR Origin (XR Rig) > Camera Offset > LeftHand Controller`
3. Selectează `LeftHand Controller`
4. În Inspector jos: **Add Component**
5. Caută: **XR Direct Interactor**
6. Apasă Add
7. **Repetă pașii 3-6 pentru `RightHand Controller`**

✅ Asta e tot pentru controllere!

---

### PASUL 2: Configurare Mingi (SUPER SIMPLU!)

**Pentru fiecare minge (Baseball, Basketball, Football, etc.):**

1. Selectează mingea în Hierarchy (care DEJA are Rigidbody și XR Grab Interactable)
2. În Inspector: **Add Component**
3. Caută și adaugă: **Throwable**
4. În scriptul Throwable, setează masa (opțional):
   - Baseball: 0.15
   - Basketball: 0.62
   - Football: 0.42
   - etc.

**GATA! Scriptul configurează setările de throw!**

📝 **Important:**
- Scriptul NU adaugă Rigidbody sau XR Grab Interactable
- Folosește componentele pe care le-ai setat tu deja
- Doar configurează setările de throw și detectează coliziuni

---

### PASUL 3: Creează Pisici/Baloane Plutitoare 🐱

1. **Adaugă modelul pisicii (sau sphere pentru balon):**
   - Trage modelul pisicii în scenă UNDE VREI (în aer!)
   - SAU: Right-click în Hierarchy → 3D Object → Sphere

2. **Adaugă Collider (dacă nu are deja):**
   - Pisica trebuie să aibă un Collider (Box/Mesh/Sphere)
   - Verifică că Collider-ul NU e Trigger

3. **Adaugă script:**
   - Selectează pisica
   - Add Component → **Balloon**

4. **Setări Balloon:**
   - **Float In Air**: ✓ (TRUE) - pisica plutește, nu cade!
   - **Enable Bobbing**: ✓ (TRUE) - mișcare sus-jos
   - **Bobbing Amount**: 0.3 (cât de mult se mișcă)
   - **Bobbing Speed**: 1.0 (cât de repede)
   - **Min Impact Force**: 1.0 (cât de tare trebuie lovită)
   - **Points**: 10

5. **Creează Tag-ul "Cat" sau "Balloon":**
   - Sus-dreapta în Inspector: Tag → Add Tag
   - Click pe "+" și scrie "Cat" (sau "Balloon")
   - Selectează pisica înapoi
   - În Inspector sus: Tag → "Cat"

**✨ Pisica va pluti în aer și se va mișca ușor sus-jos!**

---

### PASUL 4: GameManager pentru scor (OPȚIONAL)

Dacă vrei să vezi scorul:

1. **Creează GameManager:**
   - Right-click în Hierarchy → Create Empty
   - Redenumește-l "GameManager"
   - Add Component → **GameManager**

2. **Creează UI pentru scor:**
   - Right-click în Hierarchy → UI → Canvas
   - Right-click pe Canvas → UI → Text - TextMeshPro
   - Poziționează textul unde vrei (ex: sus-stânga)

3. **Link-ează textul:**
   - Selectează GameManager
   - Trage obiectul Text în câmpul "Score Text"

---

## 🎮 Cum să testezi:

1. **Pune pisicile unde vrei în scenă** (vor pluti acolo unde le pui!)
2. **Apasă Play**
3. **Uită-te în Console** - ar trebui să vezi:
   ```
   [Throwable] Basketball configurat! Mass: 0.62kg
   [Balloon] Cat setup complet! Float: true, Bobbing: true
   ```
4. **În VR:**
   - Apropie controllerul de minge
   - Apasă **Grip Button** (butonul lateral)
   - Aruncă mingea spre pisică
   - **💥 BOOM! Pisica explodează!** 🎉

---

## ⚠️ Troubleshooting:

### "Nu pot apuca mingea!"
- ✅ Ai adăugat **XR Direct Interactor** pe controllere?
- ✅ Ai **XR Interaction Manager** în scenă?
- ✅ Mingea are **Rigidbody** și **XR Grab Interactable**?
- ✅ Mingea are scriptul **Throwable**?

### "Pisica cade jos în loc să plutească!"
- ✅ Verifică că scriptul **Balloon** are **Float In Air** = TRUE
- ✅ Verifică că scriptul Balloon e atașat pe pisică
- ✅ Uită-te în Console pentru mesaje de eroare

### "Pisica nu explodează când e lovită!"
- ✅ Verifică că pisica are Tag-ul "Cat" sau "Balloon" (nu doar numele!)
- ✅ Verifică că pisica are un **Collider** (NU Trigger!)
- ✅ Verifică **Min Impact Force** - scade valoarea la 0.5 dacă e prea greu
- ✅ Aruncă mingea mai tare!
- ✅ Uită-te în Console - ar trebui să vezi "lovit cu forță: X"

### "Mingea nu se aruncă bine"
- Verifică că **Throw On Detach** = true în XR Grab Interactable
- Verifică că Rigidbody are **Use Gravity** = true
- Ajustează **Throw Velocity Scale** în scriptul Throwable (1.5-2.0)

---

## 📊 Valori recomandate:

### Pentru mingi:
| Minge       | Mass | Throw Scale |
|-------------|------|-------------|
| Golf        | 0.05 | 2.0         |
| Baseball    | 0.15 | 1.8         |
| Tennis      | 0.06 | 1.5         |
| Football    | 0.42 | 1.5         |
| Basketball  | 0.62 | 1.3         |
| Soccer      | 0.43 | 1.5         |
| Volleyball  | 0.27 | 1.4         |

### Pentru pisici/baloane:
- **Bobbing Amount**: 0.2-0.5 (mai mult = mișcare mai mare)
- **Bobbing Speed**: 0.5-2.0 (mai mult = mișcare mai rapidă)
- **Min Impact Force**: 0.5-2.0 (mai puțin = mai ușor de spart)

---

## 🎯 Rezumat RAPID:

1. ✅ Adaugă **XR Direct Interactor** pe ambele controllere
2. ✅ Adaugă scriptul **Throwable** pe fiecare minge
3. ✅ Adaugă scriptul **Balloon** pe pisici și Tag "Cat"
4. ✅ Pune pisicile unde vrei în scenă (vor pluti acolo!)
5. ✅ Apasă Play și aruncă mingi în pisici! 🐱💥

**Pisicile plutesc în aer și explodează când sunt lovite!** 🚀

Succes! 🎮🐱
