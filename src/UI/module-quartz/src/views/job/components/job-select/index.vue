<script>
import { mixins } from 'netmodular-ui'

const api = $api.quartz.job

export default {
  mixins: [mixins.select],
  data() {
    return {
      action: this.query
    }
  },
  props: {
    moduleId: {
      type: String
    }
  },
  methods: {
    query() {
      if (this.moduleId) {
        return api.jobSelect(this.moduleId)
      } else {
        return new Promise(resolve => {
          resolve([])
        })
      }
    }
  },
  watch: {
    moduleId(newVal, oldVal) {
      if (oldVal) this.reset()
      this.refresh()
    }
  }
}
</script>
