import Emitter from "tiny-emitter";

const EVENT_NAME = "movie:toggle"

const emitter = new Emitter();

export default function useMovieTarget() {
  function open(movie, mymovie) {
    emitter.emit(EVENT_NAME, { movie , mymovie });
  }

  function listen(fn) {
    emitter.on(EVENT_NAME, fn);
  }

  return { open, listen };
}
