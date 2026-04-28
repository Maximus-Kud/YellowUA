import { Link } from 'react-router-dom';
import uaIcon from '../../assets/icons/ua.webp'
import yellowUaIcon from '../../assets/icons/yellowUa-logo.svg'





function Header() {
  return (
    <div id='headers'>
      <div id='header-top'>
        <div className='header-content'>
          <div id='left-part'>
            <div id='hotline-number'>
              (093) 811 28 44
              <svg height="800px" width="800px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" enable-background="new 0 0 50 50" transform="matrix(6.123233995736766e-17,1,1,-6.123233995736766e-17,0,0)">
                <path fill="#231F20" d="M15.563,40.836c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293l15-15 c0.391-0.391,0.391-1.023,0-1.414l-15-15c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414l14.293,14.293L15.563,39.422 C15.172,39.813,15.172,40.446,15.563,40.836z" />
              </svg>
            </div>
            <div id='divider'></div>
            <div id='credit'>Кредит</div>
            <div id='service-centre'>Сервісний центр</div>
            <div id='stock'>Акції</div>
            <div id='blog'>Блог</div>
            <div id='contacts'>Контакти</div>
          </div>

          <div id='right-part'>
            <img src={uaIcon} alt={uaIcon} />
            UA
            <svg height="800px" width="800px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" enable-background="new 0 0 50 50" transform="matrix(6.123233995736766e-17,1,1,-6.123233995736766e-17,0,0)">
              <path fill="#231F20" d="M15.563,40.836c0.195,0.195,0.451,0.293,0.707,0.293s0.512-0.098,0.707-0.293l15-15 c0.391-0.391,0.391-1.023,0-1.414l-15-15c-0.391-0.391-1.023-0.391-1.414,0s-0.391,1.023,0,1.414l14.293,14.293L15.563,39.422 C15.172,39.813,15.172,40.446,15.563,40.836z" />
            </svg>
          </div>
        </div>
      </div>


      <div id='header-main'>
        <div className='header-content'>
          <Link to="/"><img id='yellow-icon' src={yellowUaIcon} alt={yellowUaIcon} /></Link>

          <div id="search-input">
            <input type='text' placeholder='Пошук товарів' />
            <svg id='search-icon' width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path d="M17.5 17.5003L13.7617 13.7553M15.8334 8.75033C15.8334 10.6289 15.0871 12.4306 13.7587 13.759C12.4303 15.0874 10.6286 15.8337 8.75002 15.8337C6.8714 15.8337 5.06973 15.0874 3.74135 13.759C2.41296 12.4306 1.66669 10.6289 1.66669 8.75033C1.66669 6.87171 2.41296 5.07004 3.74135 3.74165C5.06973 2.41327 6.8714 1.66699 8.75002 1.66699C10.6286 1.66699 12.4303 2.41327 13.7587 3.74165C15.0871 5.07004 15.8334 6.87171 15.8334 8.75033Z" stroke="white" stroke-opacity="0.4" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
            </svg>
          </div>
          
          <div id='icons-block'>
            <button id='login-button'>
              <svg width="20" height="20" viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path d="M9.99998 10.0003C12.3012 10.0003 14.1666 8.13485 14.1666 5.83366C14.1666 3.53247 12.3012 1.66699 9.99998 1.66699C7.69879 1.66699 5.83331 3.53247 5.83331 5.83366C5.83331 8.13485 7.69879 10.0003 9.99998 10.0003Z" stroke="black" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M14.1667 11.667H14.46C15.0692 11.6672 15.6574 11.8898 16.1141 12.2931C16.5708 12.6963 16.8645 13.2525 16.94
                    13.857L17.2658 16.4603C17.2952 16.6949 17.2742 16.9329 17.2045 17.1588C17.1348 17.3846 17.0178 17.593 16.8614
                    17.7702C16.7049 17.9473 16.5126 18.0892 16.2971 18.1863C16.0817 18.2835 15.848 18.3337 15.6117 18.3337H4.38834C4.15199
                    18.3337 3.91834 18.2835 3.70288 18.1863C3.48742 18.0892 3.29509 17.9473 3.13866 17.7702C2.98222 17.593 2.86525 17.3846
                    2.79551 17.1588C2.72578 16.9329 2.70487 16.6949 2.73418 16.4603L3.05918 13.857C3.13476 13.2522 3.42869 12.6958 3.8857
                    12.2925C4.34272 11.8892 4.93132 11.6668 5.54084 11.667H5.83334" stroke="black" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
              </svg>
              <span style={{fontFamily: 'Montserrat-SemiBold'}}>Увійти</span>
            </button>

            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
              <g opacity="0.64" clip-path="url(#clip0_1928_120)">
                <path d="M7 20H17" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M6 6L12 5L18 6" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M12 3V20" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M9 12L6 6L3 12C3 12.7956 3.31607 13.5587 3.87868 14.1213C4.44129 14.6839 5.20435 15 6 15C6.79565 15 7.55871 14.6839 8.12132 14.1213C8.68393 13.5587 9 12.7956 9 12Z" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M21 12L18 6L15 12C15 12.7956 15.3161 13.5587 15.8787 14.1213C16.4413 14.6839 17.2044 15 18 15C18.7956 15 19.5587 14.6839 20.1213 14.1213C20.6839 13.5587 21 12.7956 21 12Z" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
              </g>
              <defs>
                <clipPath id="clip0_1928_120">
                  <rect width="24" height="24" fill="white" />
                </clipPath>
              </defs>
            </svg>

            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
              <g opacity="0.64">
                <path d="M3.97689 9.84C4.01712 9.33881 4.24464 8.87115 4.61417 8.53017C4.98369 8.18918 5.46808 7.9999 5.97089 8H18.0289C18.5317
                  7.9999 19.0161 8.18918 19.3856 8.53017C19.7551 8.87115 19.9827 9.33881 20.0229 9.84L20.8259 19.84C20.848 20.1152 20.8129 20.392
                  20.7227 20.6529C20.6326 20.9139 20.4894 21.1533 20.3022 21.3563C20.115 21.5592 19.8878 21.7211 19.6349 21.8319C19.382 21.9427 19.109
                  21.9999 18.8329 22H5.16689C4.89081 21.9999 4.61774 21.9427 4.36487 21.8319C4.112 21.7211 3.8848 21.5592 3.69759 21.3563C3.51037
                  21.1533 3.36719 20.9139 3.27706 20.6529C3.18693 20.392 3.1518 20.1152 3.17389 19.84L3.97689 9.84V9.84Z" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
                <path d="M16 11V6C16 4.93913 15.5786 3.92172 14.8284 3.17157C14.0783 2.42143 13.0609 2 12 2C10.9391 2 9.92172 2.42143 9.17157 3.17157C8.42143
                  3.92172 8 4.93913 8 6V11" stroke="white" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" />
              </g>
            </svg>
          </div>
        </div>
      </div>
    </div>
  )
}


export default Header;