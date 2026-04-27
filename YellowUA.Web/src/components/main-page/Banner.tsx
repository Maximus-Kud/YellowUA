import s26Ultra from '../../assets/banners/s26-ultra.jpg'
import iphone17 from '../../assets/banners/iphone17.jpg'
import cashback from '../../assets/banners/cashback.jpg'





function Banner() {
  return (
    <div id="banner">
      <div id='image'>
        <img className='current-banner' src={s26Ultra} alt={s26Ultra} />
      </div>

      <div id='slides'>
        {/* <div className='current-slide'>iPhone 17</div> */}
        <div className='slide'>Galaxy S26 ULTRA</div>
        <div className='slide'>iPhone 17</div>
        <div className='slide'>Cashback</div>
        <div className='slide'>EcoFlow DELTA 3</div>
        <div className='slide'>Telegram</div>
      </div>
    </div>
  )
}


export default Banner;