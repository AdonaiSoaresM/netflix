import Emitter from "tiny-emitter";

const EVENT_NAME = "movie:toggle"

const emitter = new Emitter();

export default function useMovieTarget() {
  function open(movie) {
    emitter.emit(EVENT_NAME, movie);
  }

  function listen(fn) {
    emitter.on(EVENT_NAME, fn);
  }

  return { open, listen };
}
